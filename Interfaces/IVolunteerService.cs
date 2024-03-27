using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface IVolunteerService
    {
        public Task<GeneralResponseDTO> CreateVolunteer(VolunteerDTO VolunteerDTO);
        public Task<GeneralResponseDTO> UpdateVolunteer(int VolunteerID, VolunteerDTO VolunteerDTO);
        public Task<GeneralResponseDTO> DeleteVolunteer(int VolunteerID);
        public Task<List<VolunteerDTO>> GetVolunteersByCount(int PageNumber, int PageSize);
        public Task<VolunteerDTO> GetVolunteerByID(int VolunteerID);

    }
}
