using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]

	public class ParticipantController : Controller
    {
        private readonly IParticipantService _ParticipantService;
        public ParticipantController(IParticipantService ParticipantService) {
            _ParticipantService = ParticipantService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateParticipantAndEnroll([FromBody] ParticipantDTO ParticipantDTO, int LearningProgramID)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            // Get the user ID from the token
            if (userId != null) 
              ParticipantDTO.CreateBy = userId;

            var Result = await _ParticipantService.CreateParticipantAndEnroll(ParticipantDTO, LearningProgramID);
            if(Result.isSuccess)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpPut]
		[Authorize("Admin")]

		public async Task<IActionResult> UpdateParticipant(int ParticipantID,[FromBody] ParticipantDTO ParticipantDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            ParticipantDTO.UpdateBy = userId;
            var Result = await _ParticipantService.UpdateParticipant(ParticipantID, ParticipantDTO);
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
		[Authorize("Admin")]

		public async Task<IActionResult> DeleteParticipant(int ParticipantID)
        {
           
            var Result = await _ParticipantService.DeleteParticipant(ParticipantID);
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
		[Authorize("Admin")]

		public async Task<IActionResult> GetParticipantsByCount(int PageNumber = 1, int PageSize = 10)
        {
            var RetrieveParticipants = await _ParticipantService.GetParticipantsByCount(PageNumber, PageSize);
            if (RetrieveParticipants.Count == 0)
                return BadRequest("No Participant was found!");
     
            return Ok(RetrieveParticipants);
        }
        [HttpGet]
		[Authorize("Admin")]

		public async Task<IActionResult> GetParticipantByID(int ParticipantID)
        {
            var RetrieveParticipant = await _ParticipantService.GetParticipantByID(ParticipantID);
            if (RetrieveParticipant == null)
                return NotFound($"Participant with ID {ParticipantID} was not found!");
            return Ok(RetrieveParticipant);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddImagesToParticipant(List<IFormFile> Images, int ParticipantID)
        {
            var Result = await _ParticipantService.AddImagesToParticipant(Images, ParticipantID);

            if (Result.isSuccess)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }

    }
}
