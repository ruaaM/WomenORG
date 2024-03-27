using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]

	public class PartnershipController : Controller
    {
        private readonly IPartnershipService _PartnershipService;
        public PartnershipController(IPartnershipService PartnershipService) {
            _PartnershipService = PartnershipService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePartnership([FromBody] PartnershipDTO PartnershipDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            // Get the user ID from the token
            if (userId != null) 
              PartnershipDTO.CreateBy = userId;

            var Result = await _PartnershipService.CreatePartnership(PartnershipDTO);
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

		public async Task<IActionResult> UpdatePartnership(int PartnershipID,[FromBody] PartnershipDTO PartnershipDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            PartnershipDTO.UpdateBy = userId;
            var Result = await _PartnershipService.UpdatePartnership(PartnershipID, PartnershipDTO);
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

		public async Task<IActionResult> DeletePartnership(int PartnershipID)
        {
           
            var Result = await _PartnershipService.DeletePartnership(PartnershipID);
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

		public async Task<IActionResult> GetPartnershipsByCount(int PageNumber = 1, int PageSize = 10)
        {
            var RetrievePartnerships = await _PartnershipService.GetPartnershipsByCount(PageNumber, PageSize);
            if (RetrievePartnerships.Count == 0)
                return BadRequest("No Partnership was found!");
     
            return Ok(RetrievePartnerships);
        }
        [HttpGet]
		[Authorize("Admin")]

		public async Task<IActionResult> GetPartnershipByID(int PartnershipID)
        {
            var RetrievePartnership = await _PartnershipService.GetPartnershipByID(PartnershipID);
            if (RetrievePartnership == null)
                return NotFound($"Partnership with ID {PartnershipID} was not found!");
            return Ok(RetrievePartnership);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddImagesToPartnership(List<IFormFile> Images, int PartnershipID)
        {
            var Result = await _PartnershipService.AddImagesToPartnership(Images, PartnershipID);

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
