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
    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;
        public ParticipantService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions)
        {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
        }
        public async Task<GeneralResponseDTO> CreateParticipantAndEnroll([FromBody] ParticipantDTO ParticipantDTO, int LearningProgramDetailesID)
        {
            try
            {
                var ParticipantSpecializations = new List<ParticipantSpecialization>();
                if (ParticipantDTO == null)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter some data", false, 400, null);
                
                if(LearningProgramDetailesID == 0 )
                    return _reusableFunctions.FillGeneralResponseWithData("You must have learning program id", false, 400, null);
             
                var isLearningProgramExist = await _context.LearningProgramDetails.FindAsync(LearningProgramDetailesID);    
             
                if (isLearningProgramExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Learning Progam with Id {LearningProgramDetailesID} was not found ", false, 404, null);

                var ParticipantModel = _mapper.Map<ParticipantDTO, Participant>(ParticipantDTO);
                ParticipantModel.CreatedAt = DateTime.Now;
                ParticipantModel.Status = true;

                await _context.Participant.AddAsync(ParticipantModel);
                await _context.SaveChangesAsync();

                if (ParticipantDTO.SpecializationIDs.Count > 0)
                    foreach (var id in ParticipantDTO.SpecializationIDs)
                    {
                        var ParticipantSpecialization = new ParticipantSpecialization()
                        {
                            ParticipantID = ParticipantModel.ParticipantID,
                            CreatedAt = DateTime.Now,
                            SpecializationID = id,
                            CreateBy = ParticipantDTO.CreateBy,
                            Status = true,
                        };
                        ParticipantSpecializations.Add(ParticipantSpecialization);

                    }
                await _context.ParticipantSpecialization.AddRangeAsync(ParticipantSpecializations);
                await _context.SaveChangesAsync();

                var Enrollments = new Enrollment()
                {
                    ParticipantID = ParticipantModel.ParticipantID,
                    LearningProgramDetailsID = LearningProgramDetailesID,
                    EnrollmentDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreateBy = ParticipantDTO.CreateBy,
                    Status = true,
                    Description = ParticipantDTO.EnrollmentDescription,
                    PaymentStatusID = 1,
                    EnrollmentStatusID = 1,
                };

                await _context.Enrollment.AddAsync(Enrollments);
                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData("new participant added and enrolled successfully", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);
            }
        }
        public async Task<GeneralResponseDTO> UpdateParticipant(int ParticipantID, ParticipantDTO ParticipantDTO)
        {
            if (ParticipantID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("You must enter ParticipantID", false, 400, null);

            var IsParticipantExist = await _context.Participant.FindAsync(ParticipantID);
            if (IsParticipantExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"Participant with {ParticipantID} was not found!", false, 404, null);

            if (ParticipantDTO == null)
                return _reusableFunctions.FillGeneralResponseWithData($"\"You must enter some data", false, 400, null);

            IsParticipantExist.FirstName = ParticipantDTO.FirstName ?? IsParticipantExist.FirstName;
            IsParticipantExist.LastName = ParticipantDTO.LastName ?? IsParticipantExist.LastName;
            IsParticipantExist.Email = ParticipantDTO.Email ?? IsParticipantExist.Email;
            IsParticipantExist.Age = ParticipantDTO.Age == 0 ? IsParticipantExist.Age : ParticipantDTO.Age;
            IsParticipantExist.StreetID = ParticipantDTO.StreetID == 0 ? IsParticipantExist.StreetID : ParticipantDTO.StreetID;
            IsParticipantExist.Description = ParticipantDTO.Description ?? IsParticipantExist.Description;
            IsParticipantExist.Nationality = ParticipantDTO.Nationality ?? IsParticipantExist.Nationality;
            IsParticipantExist.PhoneNumber = ParticipantDTO.PhoneNumber ?? IsParticipantExist.PhoneNumber;
            IsParticipantExist.PlaceOfWork = ParticipantDTO.PlaceOfWork ?? IsParticipantExist.PlaceOfWork;
            IsParticipantExist.IsEmployee = ParticipantDTO.IsEmployee ?? IsParticipantExist.IsEmployee;
            IsParticipantExist.Gender = ParticipantDTO.Gender ?? IsParticipantExist.Gender;
            IsParticipantExist.Status = ParticipantDTO.Status ?? IsParticipantExist.Status;
            IsParticipantExist.DateofBirth = ParticipantDTO.DateofBirth ?? IsParticipantExist.DateofBirth;
            IsParticipantExist.UpdatedAt = DateTime.Now;
            IsParticipantExist.UpdateBy = ParticipantDTO.UpdateBy;



            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData($"Paticipant {IsParticipantExist.FirstName} updated successfully", true, 200, null);
        }
        public async Task<GeneralResponseDTO> DeleteParticipant(int ParticipantID)
        {
            try
            {
                if (ParticipantID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Participant Id", false, 400, null);
                var isParticipantExist = await _context.Participant.FindAsync(ParticipantID);
                if (isParticipantExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Participant with this {ParticipantID} Id was found!", false, 404, null);
                var isParticipantSpecializationExist = await _context.ParticipantSpecialization.Where(s => s.ParticipantID == ParticipantID).ToListAsync();

                _context.Participant.Remove(isParticipantExist);
                if (isParticipantSpecializationExist != null)
                    _context.ParticipantSpecialization.RemoveRange(isParticipantSpecializationExist);

                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Participant with {ParticipantID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }
        public async Task<List<ParticipantDTO>> GetParticipantsByCount(int PageNumber, int PageSize)
        {
            var Participants = await _context.Participant
                                              .OrderByDescending(a => a.CreatedAt)
                                              .Where(l => l.Status)
                                              .Skip((PageNumber - 1) * PageSize)
                                              .Take(PageSize)
                                              .ToListAsync();

            var ParticipantsDTO = new List<ParticipantDTO>();
            //var ParticipantImages = new List<String>();
            //var PArticipantSpecializations = new List<ParticipantSpecialization>();

            foreach (var Participant in Participants)
            {
                var ParticipantDTO = _mapper.Map<ParticipantDTO>(Participant);
                var ParticipantImages = await _context.ParticipantMedia.Where(p=>p.ParticipantID == Participant.ParticipantID).ToListAsync();
                var ParticipantSpecializations = await _context.ParticipantSpecialization.Where(p=>p.ParticipantID == Participant.ParticipantID).ToListAsync();
                ParticipantDTO.ParticipantImagesPaths.AddRange(ParticipantImages.Select(p => p.FilePath));
                ParticipantDTO.SpecializationIDs.AddRange(ParticipantSpecializations.Select(p => p.SpecializationID));
                ParticipantsDTO.Add(ParticipantDTO);
            }
            return ParticipantsDTO;
        }
        public async Task<ParticipantDTO> GetParticipantByID(int ParticipantID)
        {
            var ParticipantByID = await _context.Participant.FindAsync(ParticipantID);

            var ParticipantSpecializations = await _context.ParticipantSpecialization
                .Where(p=>p.ParticipantID == ParticipantID)
                .ToListAsync();

            var ParticipantImages = await _context.ParticipantMedia
                .Where(p => p.ParticipantID == ParticipantID)
                .ToListAsync();
            
            var ParticipantDTO = _mapper.Map<ParticipantDTO>(ParticipantByID);

            ParticipantDTO.ParticipantImagesPaths
                .AddRange(ParticipantImages.Select(p=>p.FilePath));

            ParticipantDTO.SpecializationIDs
                .AddRange(ParticipantSpecializations
                .Select(p => p.SpecializationID));
            return ParticipantDTO;

        }
        public async Task<GeneralResponseDTO> AddImagesToParticipant(List<IFormFile> Images, int ParticipantID)
        {
                string errorMessage;
            var ParticipantMedia = new ParticipantMedia();
            if (Images == null || Images.Count == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No files uploaded.", false, 400, null);
            if (ParticipantID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No Participant ID was found", false, 400, null);

            var isParticipantExist = await _context.Participant.FindAsync(ParticipantID);
            if (isParticipantExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"No Participant with ID {ParticipantID} was found", false, 404, null);

            var uploadedMedia = new List<ParticipantMedia>();
            foreach (var Image in Images)
            {
                if (!ImageValidation.IsImageValid(Image, out errorMessage))
                    return _reusableFunctions.FillGeneralResponseWithData(errorMessage, false, 400, null);

                var UploadedImage = _reusableFunctions.UploadImage(Image, "ParticipantImages");
                ParticipantMedia.Status = true;
                ParticipantMedia.CreatedAt = DateTime.Now;
                ParticipantMedia.Status = true;
                ParticipantMedia.ParticipantID = ParticipantID;
                ParticipantMedia.FileName = UploadedImage.FileName;
                ParticipantMedia.FilePath = UploadedImage.FilePath;

                uploadedMedia.Add(ParticipantMedia);
            }

            await _context.ParticipantMedia.AddRangeAsync(uploadedMedia);
            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData("Images have been uploaded successfully.", true, 200, null);
        }
    }
}
