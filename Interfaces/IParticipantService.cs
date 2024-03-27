using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface IParticipantService
    {
        public Task<GeneralResponseDTO> CreateParticipantAndEnroll(ParticipantDTO ParticipantDTO, int LearningProgramDetailesID);
        public Task<GeneralResponseDTO> UpdateParticipant(int ParticipantID, ParticipantDTO ParticipantDTO);
        public Task<GeneralResponseDTO> DeleteParticipant(int ParticipantID);
        public Task<List<ParticipantDTO>> GetParticipantsByCount(int PageNumber, int PageSize);
        public Task<ParticipantDTO> GetParticipantByID(int ParticipantID);
        public Task<GeneralResponseDTO> AddImagesToParticipant(List<IFormFile> Images, int ParticipantID);

    }
}
