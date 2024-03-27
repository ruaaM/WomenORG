using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]

	public class VolunteerController : Controller
    {
        private readonly IVolunteerService _VolunteerService;
        public VolunteerController(IVolunteerService VolunteerService) {
            _VolunteerService = VolunteerService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateVolunteer([FromBody] VolunteerDTO VolunteerDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            // Get the user ID from the token
            if (userId != null) 
              VolunteerDTO.CreateBy = userId;

            var Result = await _VolunteerService.CreateVolunteer(VolunteerDTO);
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

		public async Task<IActionResult> UpdateVolunteer(int VolunteerID,[FromBody] VolunteerDTO VolunteerDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            VolunteerDTO.UpdateBy = userId;
            var Result = await _VolunteerService.UpdateVolunteer(VolunteerID, VolunteerDTO);
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

		public async Task<IActionResult> DeleteVolunteer(int VolunteerID)
        {
           
            var Result = await _VolunteerService.DeleteVolunteer(VolunteerID);
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

		public async Task<IActionResult> GetVolunteersByCount(int PageNumber = 1, int PageSize = 10)
        {
            var RetrieveVolunteers = await _VolunteerService.GetVolunteersByCount(PageNumber, PageSize);
            if (RetrieveVolunteers.Count == 0)
                return BadRequest("No Volunteer was found!");
     
            return Ok(RetrieveVolunteers);
        }
        [HttpGet]
		[Authorize("Admin")]

		public async Task<IActionResult> GetVolunteerByID(int VolunteerID)
        {
            var RetrieveVolunteer = await _VolunteerService.GetVolunteerByID(VolunteerID);
            if (RetrieveVolunteer == null)
                return NotFound($"Volunteer with ID {VolunteerID} was not found!");
            return Ok(RetrieveVolunteer);
        }


    }
}
