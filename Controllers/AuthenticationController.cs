
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WomenORG.DTOs;
using WomenORG.Interfaces;

namespace WomenORG.Controllers
{
    [Route("auth/[Controller]/[Action]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
		[Authorize("Admin")]

		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {

            var result = await _authenticationService.RegiserAsync(registerDTO);

            if (result.isSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _authenticationService.LoginAsync(loginDTO);

            if (result.isSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
