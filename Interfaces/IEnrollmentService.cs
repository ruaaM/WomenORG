using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface IEnrollmentService
    {
        public Task<GeneralResponseDTO> UpdateEnrollment(int EnrollmentID, EnrollmentDTO EnrollmentDTO);
        public Task<GeneralResponseDTO> DeleteEnrollment(int EnrollmentID);

    }
}
