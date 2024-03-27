using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface IPartnershipService
    {
        public Task<GeneralResponseDTO> CreatePartnership(PartnershipDTO PartnershipDTO);
        public Task<GeneralResponseDTO> UpdatePartnership(int PartnershipID, PartnershipDTO PartnershipDTO);
        public Task<GeneralResponseDTO> DeletePartnership(int PartnershipID);
        public Task<List<PartnershipDTO>> GetPartnershipsByCount(int PageNumber, int PageSize);
        public Task<PartnershipDTO> GetPartnershipByID(int PartnershipID);
        public Task<GeneralResponseDTO> AddImagesToPartnership(List<IFormFile> Images, int PartnershipID);

    }
}
