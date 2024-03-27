using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
	[Route("api/[controller]/[action]")]

	public class SponsorController : Controller
    {
        private readonly ISponsorService _SponsorService;
        public SponsorController(ISponsorService SponsorService) {
            _SponsorService = SponsorService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSponsor([FromBody] SponsorDTO SponsorDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            SponsorDTO.CreateBy = userId;
            var Result = await _SponsorService.CreateSponsor(SponsorDTO);
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

		public async Task<IActionResult> UpdateSponsor(int SponsorID,[FromBody] SponsorDTO SponsorDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            SponsorDTO.UpdateBy = userId;
            var Result = await _SponsorService.UpdateSponsor(SponsorID, SponsorDTO);
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

		public async Task<IActionResult> DeleteSponsor(int SponsorID)
        {
           
            var Result = await _SponsorService.DeleteSponsor(SponsorID);
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
        public async Task<IActionResult> GetSponsorsByCount(int PageNumber = 1, int PageSize = 10)
        {
            var RetrieveSponsors = await _SponsorService.GetSponsorsByCount(PageNumber, PageSize);
            if(RetrieveSponsors.Count == 0)
                return BadRequest("No Learning Program was found!");
            return Ok(RetrieveSponsors);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSponsorByID(int SponsorID)
        {
            var RetrieveSponsor = await _SponsorService.GetSponsorByID(SponsorID);
            if (RetrieveSponsor == null)
                return NotFound($"Learning Program with ID {SponsorID} was not found!");
            return Ok(RetrieveSponsor);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddImagesToSponsor(List<IFormFile> Images, int SponsorID)
        {
            var Result = await _SponsorService.AddImagesToSponsor(Images, SponsorID);

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
