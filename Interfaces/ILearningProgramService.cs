using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface ILearningProgramService
    {
        public Task<GeneralResponseDTO> CreateLearningProgram(LearningProgramDTO learningProgramDTO);
        public Task<GeneralResponseDTO> UpdateLearningProgram(int LearningProgramID,LearningProgramDTO learningProgramDTO);
        public Task<GeneralResponseDTO> DeleteLearningProgram(int LearningProgramDetailsID);
        public Task<List<LearningProgramDTO>> GetLearningProgramsByCount(int PageNumber);
        public Task<List<LearningProgramDTO>> GetFinishedLearningProgramsByCount(int PageNumber, int PageSize);
        public Task<LearningProgramDTO> GetLearningProgramByID(int LearningProgramID);
        public Task<LearningProgramDTO> GetFinishedLearningProgramByID(int LearningProgramID);
        public Task<GeneralResponseDTO> AddImagesToLearningProgram(List<IFormFile> Images, int LearningProgramID);
    }
}
