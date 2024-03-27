using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WomenORG.Data;
using WomenORG.DTOs;
using WomenORG.Helper;
using WomenORG.Interfaces;
using WomenORG.Models;

namespace WomenORG.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ReusableFunctions _reusableFunctions;

        public EnrollmentService(ApplicationDBContext context,
             IMapper mapper,
            ReusableFunctions reusableFunctions)
        {
            _context = context;
            _mapper = mapper;
            _reusableFunctions = reusableFunctions;
        }

        public async Task<GeneralResponseDTO> UpdateEnrollment(int EnrollmentID, EnrollmentDTO EnrollmentDTO)
        {
            if (EnrollmentID == 0)
                return _reusableFunctions.FillGeneralResponseWithData("You must enter EnrollmentID", false, 400, null);

            var IsEnrollmentExist = await _context.Enrollment.FindAsync(EnrollmentID);
            if (IsEnrollmentExist == null)
                return _reusableFunctions.FillGeneralResponseWithData($"Enrollment with {EnrollmentID} was not found!", false, 404, null);

            if (EnrollmentDTO == null)
                return _reusableFunctions.FillGeneralResponseWithData($"\"You must enter some data", false, 400, null);

            IsEnrollmentExist.PaymentStatusID = EnrollmentDTO.PaymentStatusID == 0 ? IsEnrollmentExist.PaymentStatusID : EnrollmentDTO.PaymentStatusID;
            IsEnrollmentExist.ParticipantID = EnrollmentDTO.ParticipantID == 0 ? IsEnrollmentExist.ParticipantID : EnrollmentDTO.ParticipantID;
            IsEnrollmentExist.EnrollmentStatusID = EnrollmentDTO.EnrollmentStatusID == 0 ? IsEnrollmentExist.EnrollmentStatusID : EnrollmentDTO.EnrollmentStatusID;
            IsEnrollmentExist.LearningProgramDetailsID = EnrollmentDTO.LearningProgramDetailsID == 0 ? IsEnrollmentExist.LearningProgramDetailsID : EnrollmentDTO.LearningProgramDetailsID;
            IsEnrollmentExist.Description = EnrollmentDTO.Description ?? IsEnrollmentExist.Description;
            IsEnrollmentExist.Status = EnrollmentDTO.Status ?? IsEnrollmentExist.Status;
            IsEnrollmentExist.EnrollmentDate = EnrollmentDTO.EnrollmentDate ?? IsEnrollmentExist.EnrollmentDate;
            IsEnrollmentExist.UpdatedAt = DateTime.Now;
            IsEnrollmentExist.UpdateBy = EnrollmentDTO.UpdateBy;

            await _context.SaveChangesAsync();
            return _reusableFunctions.FillGeneralResponseWithData($"Enrollment {IsEnrollmentExist.EnrollmentID} updated successfully", true, 200, null);
        }

        public async Task<GeneralResponseDTO> DeleteEnrollment(int EnrollmentID)
        {
            try
            {
                if (EnrollmentID == 0)
                    return _reusableFunctions.FillGeneralResponseWithData("You need to enter Enrollment Id", false, 400, null);
                var isEnrollmentExist = await _context.Enrollment.FindAsync(EnrollmentID);
                if (isEnrollmentExist == null)
                    return _reusableFunctions.FillGeneralResponseWithData($"Enrollment with this {EnrollmentID} Id was found!", false, 404, null);

                _context.Enrollment.Remove(isEnrollmentExist);
            
                await _context.SaveChangesAsync();
                return _reusableFunctions.FillGeneralResponseWithData($"Enrollment with {EnrollmentID} Id has deleted successfully!", true, 200, null);
            }
            catch (Exception ex)
            {
                return _reusableFunctions.FillGeneralResponseWithData(ex.Message, false, 400, null);

            }

        }

    }
}
