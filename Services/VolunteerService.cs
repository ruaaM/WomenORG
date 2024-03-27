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
    public class VolunteerService : IVolunteerService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;
        public VolunteerService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions)
        {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
        }
        public async Task<GeneralResponseDTO> CreateVolunteer([FromBody] VolunteerDTO VolunteerDTO)
        {
            try
            {
                if (VolunteerDTO == null)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter some data", false, 400, null);

                if (VolunteerDTO.StreetID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter StreetID", false, 400, null);

                var VolunteerModel = _mapper.Map<VolunteerDTO, Volunteer>(VolunteerDTO);
                VolunteerModel.CreatedAt = DateTime.Now;
                VolunteerModel.Status = true;
                VolunteerModel.CreateBy = VolunteerDTO.CreateBy;
                await _context.Volunteer.AddAsync(VolunteerModel);
                await _context.SaveChangesAsync();

                return _reusableFunctions.FillGeneralResponseWithData("new Volunteer added and enrolled successfully", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);
            }
        }
        public async Task<GeneralResponseDTO> UpdateVolunteer(int VolunteerID, VolunteerDTO VolunteerDTO)
        {
            if (VolunteerID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("You must enter VolunteerID", false, 400, null);

            var IsVolunteerExist = await _context.Volunteer.FindAsync(VolunteerID);
            if (IsVolunteerExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"Volunteer with {VolunteerID} was not found!", false, 404, null);

            if (VolunteerDTO == null)
                return _reusableFunctions.FillGeneralResponseWithData($"\"You must enter some data", false, 400, null);

            IsVolunteerExist.Email = VolunteerDTO.Email ?? IsVolunteerExist.Email;
            IsVolunteerExist.UpdatedAt = DateTime.Now;
            IsVolunteerExist.UpdateBy = VolunteerDTO.UpdateBy ?? IsVolunteerExist.UpdateBy;   
            IsVolunteerExist.FirstName = VolunteerDTO.FirstName ?? IsVolunteerExist.FirstName;   
            IsVolunteerExist.LastName = VolunteerDTO.LastName ?? IsVolunteerExist.LastName;   
            IsVolunteerExist.PhoneNumber = VolunteerDTO.PhoneNumber ?? IsVolunteerExist.PhoneNumber;   
            IsVolunteerExist.Experience = VolunteerDTO.Experience ?? IsVolunteerExist.Experience;   
            IsVolunteerExist.AdditionalInformation = VolunteerDTO.AdditionalInformation ?? IsVolunteerExist.AdditionalInformation;   
            IsVolunteerExist.AvailabilityStartDate = VolunteerDTO.AvailabilityStartDate ?? IsVolunteerExist.AvailabilityStartDate;   
            IsVolunteerExist.AvailabilityEndDate = VolunteerDTO.AvailabilityEndDate ?? IsVolunteerExist.AvailabilityEndDate;
            IsVolunteerExist.StreetID = VolunteerDTO.StreetID == 0 ? IsVolunteerExist.StreetID : VolunteerDTO.StreetID;

            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData($"Volunteer updated successfully", true, 200, null);
        }
        public async Task<GeneralResponseDTO> DeleteVolunteer(int VolunteerID)
        {
            try
            {
                if (VolunteerID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Volunteer Id", false, 400, null);
                var isVolunteerExist = await _context.Volunteer.FindAsync(VolunteerID);
                if (isVolunteerExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Volunteer with this {VolunteerID} Id was found!", false, 404, null);

                _context.Volunteer.Remove(isVolunteerExist);
                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Volunteer with {VolunteerID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }
        public async Task<List<VolunteerDTO>> GetVolunteersByCount(int PageNumber, int PageSize)
        {
            var Volunteers = await _context.Volunteer
                                              .OrderByDescending(a => a.CreatedAt)
                                              .Where(l => l.Status)
                                              .Skip((PageNumber - 1) * PageSize)
                                              .Take(PageSize)
                                              .ToListAsync();

            var VolunteersDTO = new List<VolunteerDTO>();
          
            foreach (var Volunteer in Volunteers)
            {
                var VolunteerDTO = _mapper.Map<VolunteerDTO>(Volunteer);
                VolunteersDTO.Add(VolunteerDTO);
            }
            return VolunteersDTO;
        }
        public async Task<VolunteerDTO> GetVolunteerByID(int VolunteerID)
        {
            var VolunteerByID = await _context.Volunteer.FindAsync(VolunteerID);
            var VolunteerDTO = _mapper.Map<VolunteerDTO>(VolunteerByID);
            return VolunteerDTO;
        }
     
    }
}
