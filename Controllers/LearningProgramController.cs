using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]

	public class LearningProgramController : Controller
    {
        private readonly ILearningProgramService _learningProgramService;
        public LearningProgramController(ILearningProgramService learningProgramService) {
            _learningProgramService = learningProgramService;
        }
        [HttpPost]
		[Authorize(Roles ="Admin")]

		public async Task<IActionResult> CreateLearningProgram([FromBody] LearningProgramDTO learningProgramDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            learningProgramDTO.CreateBy = userId;
            var Result = await _learningProgramService.CreateLearningProgram(learningProgramDTO);
            if(Result.isSuccess)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateLearningProgram(int LearningProgramDetailsID, [FromBody] LearningProgramDTO learningProgramDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            learningProgramDTO.UpdateBy = userId;
            var Result = await _learningProgramService.UpdateLearningProgram(LearningProgramDetailsID, learningProgramDTO);
            if (Result.isSuccess)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLearningProgram(int LearningProgramDetailsID)
        {
           
            var Result = await _learningProgramService.DeleteLearningProgram(LearningProgramDetailsID);
            if (Result.isSuccess)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetLearningProgramsByCount(int PageNumber = 1)
        {
            var RetrieveLearningPrograms = await _learningProgramService.GetLearningProgramsByCount(PageNumber);
            if(RetrieveLearningPrograms.Count == 0)
                return BadRequest("No Learning Program was found!");
            return Ok(RetrieveLearningPrograms);
        }
        [HttpGet]
		[AllowAnonymous]

		public async Task<IActionResult> GetLearningProgramByID(int LearningProgramID)
        {
            var RetrieveLearningProgram = await _learningProgramService.GetLearningProgramByID(LearningProgramID);
            if (RetrieveLearningProgram == null)
                return NotFound($"Learning Program with ID {LearningProgramID} was not found!");
            return Ok(RetrieveLearningProgram);
        }
        [HttpGet]
		[AllowAnonymous]

		public async Task<IActionResult> GetOurWorksByCount(int PageNumber = 1, int PageSize = 10)
        {
            var RetrieveFinishedLearningPrograms = await _learningProgramService.
                GetFinishedLearningProgramsByCount(PageNumber, PageSize);
            if (RetrieveFinishedLearningPrograms.Count == 0)
                return BadRequest("No work was found!");
            return Ok(RetrieveFinishedLearningPrograms);
        }

        [HttpGet]
		[AllowAnonymous]

		public async Task<IActionResult> GetOurWorkByID(int FinishedLearningProgramID)
        {
            var RetrieveLearningProgram = await _learningProgramService.GetFinishedLearningProgramByID(FinishedLearningProgramID);
            if (RetrieveLearningProgram == null)
                return NotFound($"work with ID {FinishedLearningProgramID} was not found!");
            return Ok(RetrieveLearningProgram);
        }
        [HttpPost]
		[Authorize("Admin")]

		public async Task<IActionResult> AddImagesToLearningProgram(List<IFormFile> Images, int LearningProgramID)
        {
            if (Images == null || Images.Count == 0)
                return BadRequest("No files uploaded.");
            if (LearningProgramID == 0)
                return BadRequest("You need to enter learning Program id");
            var Result = await _learningProgramService.AddImagesToLearningProgram(Images, LearningProgramID);
            if(Result.isSuccess)
            {
                return Ok(Result);
            }
            return BadRequest(Result);

        }

    }
}
