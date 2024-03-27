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
    public class LearningProgramService : ILearningProgramService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LearningProgramService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<GeneralResponseDTO> CreateLearningProgram(LearningProgramDTO learningProgramDTO)
        {
            try
            {
                if (learningProgramDTO == null)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter some data", false, 400, null);
              
                if (learningProgramDTO.Name == null || learningProgramDTO.LearningProgramTypeID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("Some Data are Required!", false, 400, null);
               
                var LearningProgramModel = _mapper.Map<LearningProgramDTO, LearningProgramDetails>(learningProgramDTO);
                LearningProgramModel.CreatedAt = DateTime.Now;
                LearningProgramModel.Status = true;
                LearningProgramModel.LearningProgramStatusID = 1;

                await _context.LearningProgramDetails.AddAsync(LearningProgramModel);
                await _context.SaveChangesAsync();


                var LearningProgramSpecialization = new LearningProgramSpecialization()
                {
                    SpecializationID = learningProgramDTO.SpecializationID,
                    LearningProgramDetailsID = LearningProgramModel.LearningProgramDetailsID,
                    CreatedAt = DateTime.Now,
                    CreateBy = learningProgramDTO.CreateBy,
                    Status = true,
                };
                await _context.AddAsync(LearningProgramSpecialization);
                var InstructorLearningProgram = new InstructorLearningProgram()
                {
                    LearningProgramDetailsID = LearningProgramModel.LearningProgramDetailsID,
                    InstructorID = learningProgramDTO.InstructorID,
                    Status = true,
                    CreateBy = learningProgramDTO.CreateBy,
                    CreatedAt = DateTime.Now,
                };
                await _context.AddAsync(InstructorLearningProgram);
                await _context.SaveChangesAsync();

                return _reusableFunctions.FillGeneralResponseWithData("new learning program added successfully", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);
            }

        }
        public async Task<GeneralResponseDTO> UpdateLearningProgram(int LearningProgramID, LearningProgramDTO learningProgramDTO)
        {
            try
            {
                if (LearningProgramID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You must enter LearningProgramID", false, 400, null);

                var IsLearningProgramExist = await _context.LearningProgramDetails.FindAsync(LearningProgramID);
                if (IsLearningProgramExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Learning Program with {LearningProgramID} was not found!", false, 404, null);

                if (learningProgramDTO == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"\"You must enter some data", false, 400, null);


                IsLearningProgramExist.CompletionCertificate = learningProgramDTO.CompletionCertificate ?? IsLearningProgramExist.CompletionCertificate;
                IsLearningProgramExist.Curriculum = learningProgramDTO.Curriculum ?? IsLearningProgramExist.Curriculum;
                IsLearningProgramExist.Duration = learningProgramDTO.Duration ?? IsLearningProgramExist.Duration;
                IsLearningProgramExist.LearningProgramStatusID = learningProgramDTO.LearningProgramStatusID == 0 ? IsLearningProgramExist.LearningProgramStatusID : learningProgramDTO.LearningProgramStatusID;
                IsLearningProgramExist.LearningProgramTypeID = learningProgramDTO.LearningProgramTypeID == 0 ? IsLearningProgramExist.LearningProgramTypeID : learningProgramDTO.LearningProgramTypeID;
                IsLearningProgramExist.LocationID = learningProgramDTO.LocationID == 0 ? IsLearningProgramExist.LocationID : learningProgramDTO.LocationID;
                IsLearningProgramExist.Description = learningProgramDTO.Description ?? IsLearningProgramExist.Description;
                IsLearningProgramExist.EnrollmentLimit = learningProgramDTO.EnrollmentLimit ?? IsLearningProgramExist.EnrollmentLimit;
                IsLearningProgramExist.Name = learningProgramDTO.Name ?? IsLearningProgramExist.Name;
                IsLearningProgramExist.StartDate = learningProgramDTO.StartDate ?? IsLearningProgramExist.StartDate;
                IsLearningProgramExist.EndDate = learningProgramDTO.EndDate ?? IsLearningProgramExist.EndDate;
                IsLearningProgramExist.isOnline = learningProgramDTO.isOnline ?? IsLearningProgramExist.isOnline;
                IsLearningProgramExist.Status = learningProgramDTO.Status ?? IsLearningProgramExist.Status;
                IsLearningProgramExist.Price = learningProgramDTO.Price ?? IsLearningProgramExist.Price;
                IsLearningProgramExist.UpdatedAt = DateTime.Now;
                IsLearningProgramExist.UpdateBy = learningProgramDTO.UpdateBy;

                var Specialization = await _context.LearningProgramSpecialization
                    .Where(s => s.LearningProgramDetailsID == LearningProgramID)
                    .FirstOrDefaultAsync();

                if (Specialization != null)
                    Specialization.SpecializationID = learningProgramDTO.SpecializationID == 0 ? Specialization.SpecializationID : learningProgramDTO.SpecializationID;

                var Instructor = await _context.InstructorLearningProgram
                  .Where(s => s.LearningProgramDetailsID == LearningProgramID)
                  .FirstOrDefaultAsync();

                if (Instructor != null)
                    Instructor.InstructorID = learningProgramDTO.InstructorID == 0 ? Instructor.InstructorID : learningProgramDTO.InstructorID;

                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Learning Program {IsLearningProgramExist.Name} updated successfully", true, 200, null);


            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }
        }
        public async Task<GeneralResponseDTO> DeleteLearningProgram(int LearningProgramDetailsID)
        {
            try
            {
                if (LearningProgramDetailsID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Learning Program Id", false, 400, null);
               
                var isLearningProgramExist = await _context.LearningProgramDetails.FindAsync(LearningProgramDetailsID);
                if (isLearningProgramExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"No Learning Program with this {LearningProgramDetailsID} Id was found!", false, 404, null);
              
                _context.LearningProgramDetails.Remove(isLearningProgramExist);
               
                var isLearningProgramSpecializationExist = await _context.LearningProgramSpecialization.Where(s => s.LearningProgramDetailsID == LearningProgramDetailsID).FirstOrDefaultAsync();
               
                if (isLearningProgramSpecializationExist != null)
                    _context.LearningProgramSpecialization.Remove(isLearningProgramSpecializationExist);
               
                var isLearningProgramInstructorExist = await _context.InstructorLearningProgram.Where(s => s.LearningProgramDetailsID == LearningProgramDetailsID).FirstOrDefaultAsync();

                if (isLearningProgramInstructorExist != null)
                    _context.InstructorLearningProgram.Remove(isLearningProgramInstructorExist);

                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Learning Program with {LearningProgramDetailsID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }
        public async Task<List<LearningProgramDTO>> GetLearningProgramsByCount(int PageNumber)
        {
            int PageSize = 10;
            var LearningPrograms = new List<LearningProgramDetails>();
            var LearningProgramsDTO = new List<LearningProgramDTO>();
            try
            {
                 LearningPrograms = await _context.LearningProgramDetails
                                 .OrderByDescending(a => a.CreatedAt)
                                 .Where(l => l.Status)
                                 .Skip((PageNumber - 1) * PageSize)
                                 .Take(PageSize)
                                 .ToListAsync();
                foreach (var learningProgram in LearningPrograms)
                {
                    var LearningProgramDTO = _mapper.Map<LearningProgramDTO>(learningProgram);
                    LearningProgramsDTO.Add(LearningProgramDTO);
                }
                return LearningProgramsDTO;
            }
            catch (Exception)
            {
                return LearningProgramsDTO;
            }

        }
        public async Task<LearningProgramDTO> GetLearningProgramByID(int LearningProgramID)
        {
            var LearningProgramByID = await _context.LearningProgramDetails.FindAsync(LearningProgramID);
            if(LearningProgramByID == null)
            {
                return null;
            }
            var LearningProgramDTO = _mapper.Map<LearningProgramDTO>(LearningProgramByID);
            return LearningProgramDTO;
        }
        //Our Work or Portfolio
        public async Task<List<LearningProgramDTO>> GetFinishedLearningProgramsByCount(int PageNumber, int PageSize)
        {
            var FinishedLearningPrograms = await _context.LearningProgramDetails
                                               .OrderByDescending(a => a.CreatedAt)
                                               .Include(l => l.LearningProgramStatus)
                                               .Where(l => l.Status && l.LearningProgramStatus.IsFinal)
                                               .Skip((PageNumber - 1) * PageSize)
                                               .Take(PageSize)
                                               .ToListAsync();
            var LearningProgramsDTO = new List<LearningProgramDTO>();
            //var LearningProgramImages = new List<ima>
            foreach (var learningProgram in FinishedLearningPrograms)
            {
                var LearningProgramDTO = _mapper.Map<LearningProgramDTO>(learningProgram);
                LearningProgramsDTO.Add(LearningProgramDTO);
                var LearningProgramImages = await _context.PortfolioMedia
             .Where(PM => PM.LearningProgramDetailsID == learningProgram.LearningProgramDetailsID)
             .Select(PM => PM.FilePath)
             .ToListAsync();

                if (LearningProgramImages.Count != 0)
                    LearningProgramDTO.learningProgramImagesPaths.AddRange(LearningProgramImages);

            }
            return LearningProgramsDTO;
        }
        public async Task<LearningProgramDTO> GetFinishedLearningProgramByID(int LearningProgramID)
        {
            var FinishedLearningProgramByID = await _context
                .LearningProgramDetails.Where(l => l.Status && l.LearningProgramStatusID == 9)
                .FirstOrDefaultAsync(l => l.LearningProgramDetailsID == LearningProgramID);
            if (FinishedLearningProgramByID == null)
                return null;
            var LearningProgramDTO = _mapper.Map<LearningProgramDTO>(FinishedLearningProgramByID);

            var LearningProgramImages = await _context.PortfolioMedia
                .Where(PM => PM.LearningProgramDetailsID == LearningProgramID)
                .Select(PM => PM.FilePath)
                .ToListAsync();
           
            if(LearningProgramImages.Count !=0)
                LearningProgramDTO.learningProgramImagesPaths.AddRange(LearningProgramImages);
   
            return LearningProgramDTO;
        }
        public async Task<GeneralResponseDTO> AddImagesToLearningProgram(List<IFormFile> Images, int LearningProgramID)
        {
                string errorMessage;
            var PortfolioMedia = new PortfolioMedia();
            if (Images == null || Images.Count == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No files uploaded.", false, 400, null);
            if (LearningProgramID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("No Learning Program ID", false, 400, null);

            var isLearningProgramExist = await _context.LearningProgramDetails.FindAsync(LearningProgramID);
            if (isLearningProgramExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"No Learning Program with ID {LearningProgramID} was found", false, 404, null);

            var uploadedMedia = new List<PortfolioMedia>();
            foreach (var Image in Images)
            {
                if (!ImageValidation.IsImageValid(Image, out errorMessage))
                    return _reusableFunctions.FillGeneralResponseWithData(errorMessage, false, 400, null);
                

                var UploadedImage = _reusableFunctions.UploadImage(Image, "PortfolioImages");
                PortfolioMedia.Status = true;
                PortfolioMedia.CreatedAt = DateTime.Now;
                PortfolioMedia.LearningProgramDetailsID = LearningProgramID;

                uploadedMedia.Add(PortfolioMedia);
            }

            await _context.PortfolioMedia.AddRangeAsync(uploadedMedia);
            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData("Images have been uploaded successfully.", true, 200, null);
        }
    }
}
