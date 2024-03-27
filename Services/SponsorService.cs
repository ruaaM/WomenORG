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
    public class SponsorService : ISponsorService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;

        public SponsorService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions) {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
        }

        public async Task<GeneralResponseDTO> CreateSponsor([FromBody] SponsorDTO SponsorDTO)
        {
            try {
                if (SponsorDTO == null)
                   return _reusableFunctions.FillGeneralResponseWithData("You must enter some data", false, 400, null);
                if (SponsorDTO.Name == null)
                    return _reusableFunctions.FillGeneralResponseWithData("Some Data are Required!", false, 400, null);
              
                var SponsorModel = _mapper.Map<SponsorDTO, Sponsor>(SponsorDTO);
                SponsorModel.CreatedAt = DateTime.Now;
                SponsorModel.Status = true;
                await _context.Sponsor.AddAsync(SponsorModel);
                await _context.SaveChangesAsync();
                var SponsorSocialMedia = new SocialMediaLinksSponsers();
                var SponserLearning = new SponsorLearningProgram();

                if (SponsorDTO.SocialMediaLinksSponsers.Count > 0)
                {
                    foreach (var socialMedia in SponsorDTO.SocialMediaLinksSponsers)
                    {
                        SponsorSocialMedia.LinkURL = socialMedia.LinkURL;
                        SponsorSocialMedia.SponsorID = SponsorModel.SponsorID;
                        SponsorSocialMedia.Name = socialMedia.Name;
                    }
                    await _context.SocialMediaLinksSponsers.AddAsync(SponsorSocialMedia);
                    await _context.SaveChangesAsync();
                }
                
                if(SponsorDTO.LearningProgramDetailsID.Count > 0)
                {
                    foreach(var Id in SponsorDTO.LearningProgramDetailsID)
                    {
                        SponserLearning.LearningProgramDetailsID = Id;
                        SponserLearning.SponsorID = SponsorModel.SponsorID;
                        SponserLearning.CreatedAt = DateTime.Now;
                        SponserLearning.Status = true;
                        SponserLearning.CreateBy = SponsorDTO.CreateBy;
                    }
                    await _context.SponsorLearningProgram.AddAsync(SponserLearning);
                    await _context.SaveChangesAsync();
                }
                return _reusableFunctions.FillGeneralResponseWithData("new Sponsor added successfully", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);
            }
          
        }

        public async Task<GeneralResponseDTO> UpdateSponsor(int SponsorID, SponsorDTO SponsorDTO)
        {
            if (SponsorID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("You must enter SponsorID", false, 400, null);

            var IsSponsorExist = await _context.Sponsor.FindAsync(SponsorID);
            if (IsSponsorExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"Learning Program with {SponsorID} was not found!", false, 404, null);

            if (SponsorDTO == null)
                return _reusableFunctions.FillGeneralResponseWithData($"You must enter some data", false, 400, null);
            
            
            IsSponsorExist.Email = SponsorDTO.Email ?? IsSponsorExist.Email;
            IsSponsorExist.Duration = SponsorDTO.Duration ?? IsSponsorExist.Duration;
            IsSponsorExist.LocationID = SponsorDTO.LocationID == 0? IsSponsorExist.LocationID : SponsorDTO.LocationID;
            IsSponsorExist.Description = SponsorDTO.Description ?? IsSponsorExist.Description;
            IsSponsorExist.ContactName = SponsorDTO.ContactName ?? IsSponsorExist.ContactName;
            IsSponsorExist.SponsorshipStartDate = SponsorDTO.SponsorshipStartDate ?? IsSponsorExist.SponsorshipStartDate;
            IsSponsorExist.SponsorshipEndDate = SponsorDTO.SponsorshipEndDate ?? IsSponsorExist.SponsorshipEndDate;
            IsSponsorExist.Name = SponsorDTO.Name ?? IsSponsorExist.Name;
            IsSponsorExist.ContactEmail = SponsorDTO.ContactEmail ?? IsSponsorExist.ContactEmail;
            IsSponsorExist.ContactPhoneNumber = SponsorDTO.ContactPhoneNumber ?? IsSponsorExist.ContactPhoneNumber;
            IsSponsorExist.Caption = SponsorDTO.Caption ?? IsSponsorExist.Caption;
            IsSponsorExist.Status = SponsorDTO.Status ?? IsSponsorExist.Status;
            IsSponsorExist.UpdatedAt = DateTime.Now;
            IsSponsorExist.UpdateBy = SponsorDTO.UpdateBy;

            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData($"Learning Program {IsSponsorExist.Name} updated successfully", true, 200, null);
        }

        public async Task<GeneralResponseDTO> DeleteSponsor(int SponsorID)
        {
            try
            {

                if (SponsorID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Learning Program Id", false, 400, null);
                var isSponsorExist = await _context.Sponsor.FindAsync(SponsorID);
                if (isSponsorExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"No Learning Program with this {SponsorID} Id was found!", false, 404, null);

                _context.Sponsor.Remove(isSponsorExist);
                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Learning Program with {SponsorID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }

        public async Task<List<SponsorDTO>> GetSponsorsByCount(int PageNumber,int PageSize)
        {
            var Sponsors = await _context.Sponsor
                                   .OrderByDescending(a => a.CreatedAt)
                                   .Where(l=>l.Status)
                                   .Skip((PageNumber - 1) * PageSize)
                                   .Take(PageSize)
                                   .ToListAsync();
            var SponsorsDTO = new List<SponsorDTO>();
            foreach (var Sponsor in Sponsors)
            {
                var SponsorDTO = _mapper.Map<SponsorDTO>(Sponsor);
                SponsorsDTO.Add(SponsorDTO);
            }
            return SponsorsDTO;
        }

        public async Task<SponsorDTO> GetSponsorByID(int SponsorID)
        {
            var SponsorByID = await _context.Sponsor.FindAsync(SponsorID);
            var SponsorDTO = _mapper.Map<SponsorDTO>(SponsorByID);
            return SponsorDTO;
        }
        public async Task<GeneralResponseDTO> AddImagesToSponsor(List<IFormFile> Images, int SponsorID)
        {
                string errorMessage;
            var SponsorMedia = new SponsorMedia();
            if (Images == null || Images.Count == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No files uploaded.", false, 400, null);
            if (SponsorID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No Sponsor ID was found", false, 400, null);

            var isSponsorExist = await _context.Sponsor.FindAsync(SponsorID);
            if (isSponsorExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"No Sponsor with ID {SponsorID} was found", false, 404, null);

            var uploadedMedia = new List<SponsorMedia>();
            foreach (var Image in Images)
            {
                if (!ImageValidation.IsImageValid(Image, out errorMessage))
                    return _reusableFunctions.FillGeneralResponseWithData(errorMessage, false, 400, null);

                var UploadedImage = _reusableFunctions.UploadImage(Image, "SponsorImages");
                SponsorMedia.Status = true;
                SponsorMedia.CreatedAt = DateTime.Now;
                SponsorMedia.Status = true;
                SponsorMedia.SponsorID = SponsorID;
                SponsorMedia.FileName = UploadedImage.FileName;
                SponsorMedia.FilePath = UploadedImage.FilePath;

                uploadedMedia.Add(SponsorMedia);
            }

            await _context.SponsorMedia.AddRangeAsync(uploadedMedia);
            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData("Images have been uploaded successfully.", true, 200, null);
        }

    }
}
