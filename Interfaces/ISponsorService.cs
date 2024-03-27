using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface ISponsorService
    {
        public Task<GeneralResponseDTO> CreateSponsor(SponsorDTO SponsorDTO);
        public Task<GeneralResponseDTO> UpdateSponsor(int SponsorID, SponsorDTO SponsorDTO);
        public Task<GeneralResponseDTO> DeleteSponsor(int SponsorID);
        public Task<List<SponsorDTO>> GetSponsorsByCount(int PageNumber, int PageSize);
        public Task<SponsorDTO> GetSponsorByID(int SponsorID);
        public Task<GeneralResponseDTO> AddImagesToSponsor(List<IFormFile> Images, int SponsorID);


    }
}
