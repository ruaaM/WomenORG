using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]
	[Authorize("Admin")]

	public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _EnrollmentService;
        public EnrollmentController(IEnrollmentService EnrollmentService)
        {
            _EnrollmentService = EnrollmentService;
        }
     
        [HttpPut]
        public async Task<IActionResult> UpdateEnrollment(int EnrollmentntID, [FromBody] EnrollmentDTO EnrollmentntDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get the user ID from the token
            EnrollmentntDTO.UpdateBy = userId;
            var Result = await _EnrollmentService.UpdateEnrollment(EnrollmentntID, EnrollmentntDTO);
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
        public async Task<IActionResult> DeleteEnrollment(int EnrollmentntID)
        {

            var Result = await _EnrollmentService.DeleteEnrollment(EnrollmentntID);
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
