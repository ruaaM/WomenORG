using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WomenORG.Data;
using WomenORG.DTOs;
using WomenORG.Helper;
using WomenORG.Interfaces;
using WomenORG.Models;

namespace WomenORG.Services
{
    public class PartnershipService : IPartnershipService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;
        public PartnershipService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions)
        {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
        }
        public async Task<GeneralResponseDTO> CreatePartnership([FromBody] PartnershipDTO PartnershipDTO)
        {
            try
            {
                if (PartnershipDTO == null)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter some data", false, 400, null);

                if (PartnershipDTO.LocationID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter locationID", false, 400, null);

                var PartnershipModel = _mapper.Map<PartnershipDTO, Partnership>(PartnershipDTO);
                PartnershipModel.CreatedAt = DateTime.Now;
                PartnershipModel.Status = true;
                PartnershipModel.CreateBy = PartnershipDTO.CreateBy;

                await _context.Partnership.AddAsync(PartnershipModel);
                await _context.SaveChangesAsync();

                return _reusableFunctions.FillGeneralResponseWithData("new Partnership added and enrolled successfully", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);
            }
        }
        public async Task<GeneralResponseDTO> UpdatePartnership(int PartnershipID, PartnershipDTO PartnershipDTO)
        {
            if (PartnershipID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("You must enter PartnershipID", false, 400, null);

            var IsPartnershipExist = await _context.Partnership.FindAsync(PartnershipID);
            if (IsPartnershipExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"Partnership with {PartnershipID} was not found!", false, 404, null);

            if (PartnershipDTO == null)
                return _reusableFunctions.FillGeneralResponseWithData($"\"You must enter some data", false, 400, null);

            IsPartnershipExist.Email = PartnershipDTO.Email ?? IsPartnershipExist.Email;
            IsPartnershipExist.PartnerOrganization = PartnershipDTO.PartnerOrganization ?? IsPartnershipExist.PartnerOrganization;
            IsPartnershipExist.PartnershipStartDate = PartnershipDTO.PartnershipStartDate ?? IsPartnershipExist.PartnershipStartDate;
            IsPartnershipExist.PartnershipStartDate = PartnershipDTO.PartnershipStartDate ?? IsPartnershipExist.PartnershipEndDate;
            IsPartnershipExist.ContactName = PartnershipDTO.ContactName ?? IsPartnershipExist.ContactName;
            IsPartnershipExist.ContactEmail = PartnershipDTO.ContactEmail ?? IsPartnershipExist.ContactEmail;
            IsPartnershipExist.Duration = PartnershipDTO.Duration ?? IsPartnershipExist.Duration;
            IsPartnershipExist.ContactPhoneNumber = PartnershipDTO.ContactPhoneNumber ?? IsPartnershipExist.ContactPhoneNumber;
            IsPartnershipExist.LocationID = PartnershipDTO.LocationID ?? IsPartnershipExist.LocationID;
            IsPartnershipExist.UpdatedAt = DateTime.Now;
            IsPartnershipExist.UpdateBy = PartnershipDTO.UpdateBy ?? IsPartnershipExist.UpdateBy;   
            IsPartnershipExist.Caption = PartnershipDTO.Caption ?? IsPartnershipExist.Caption;   

            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData($"Partnership updated successfully", true, 200, null);
        }
        public async Task<GeneralResponseDTO> DeletePartnership(int PartnershipID)
        {
            try
            {
                if (PartnershipID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Partnership Id", false, 400, null);
                var isPartnershipExist = await _context.Partnership.FindAsync(PartnershipID);
                if (isPartnershipExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Partnership with this {PartnershipID} Id was found!", false, 404, null);

                _context.Partnership.Remove(isPartnershipExist);
                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Partnership with {PartnershipID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }
        public async Task<List<PartnershipDTO>> GetPartnershipsByCount(int PageNumber, int PageSize)
        {
            var Partnerships = await _context.Partnership
                                              .OrderByDescending(a => a.CreatedAt)
                                              .Where(l => l.Status)
                                              .Skip((PageNumber - 1) * PageSize)
                                              .Take(PageSize)
                                              .ToListAsync();

            var PartnershipsDTO = new List<PartnershipDTO>();
          
            foreach (var Partnership in Partnerships)
            {
                var PartnershipDTO = _mapper.Map<PartnershipDTO>(Partnership);
                var PartnershipImages = await _context.PartnershipMedia.Where(p=>p.PartnershipID == Partnership.PartnershipID).ToListAsync();
                PartnershipDTO.PartnershipImagesPaths.AddRange(PartnershipImages.Select(p => p.FilePath));
                PartnershipsDTO.Add(PartnershipDTO);
            }
            return PartnershipsDTO;
        }
        public async Task<PartnershipDTO> GetPartnershipByID(int PartnershipID)
        {
            var PartnershipByID = await _context.Partnership.FindAsync(PartnershipID);
            var PartnershipDTO = _mapper.Map<PartnershipDTO>(PartnershipByID);
            return PartnershipDTO;
        }
        public async Task<GeneralResponseDTO> AddImagesToPartnership(List<IFormFile> Images, int PartnershipID)
        {
                string errorMessage;
            var PartnershipMedia = new PartnershipMedia();
            if (Images == null || Images.Count == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No files uploaded.", false, 400, null);
            if (PartnershipID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No Partnership ID was found", false, 400, null);

            var isPartnershipExist = await _context.Partnership.FindAsync(PartnershipID);
            if (isPartnershipExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"No Partnership with ID {PartnershipID} was found", false, 404, null);

            var uploadedMedia = new List<PartnershipMedia>();
            foreach (var Image in Images)
            {
                if (!ImageValidation.IsImageValid(Image, out errorMessage))
                    return _reusableFunctions.FillGeneralResponseWithData(errorMessage, false, 400, null);

                var UploadedImage = _reusableFunctions.UploadImage(Image, "PartnershipImages");
                PartnershipMedia.Status = true;
                PartnershipMedia.CreatedAt = DateTime.Now;
                PartnershipMedia.PartnershipID = PartnershipID;
                PartnershipMedia.FileName = UploadedImage.FileName;
                PartnershipMedia.FilePath = UploadedImage.FilePath;
                uploadedMedia.Add(PartnershipMedia);
            }
            await _context.PartnershipMedia.AddRangeAsync(uploadedMedia);
            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData("Images have been uploaded successfully.", true, 200, null);
        }
    }
}
