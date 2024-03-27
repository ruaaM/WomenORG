using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WomenORG.Data;
using WomenORG.Models;

namespace WomenORG.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize("Admin")]
    public class AdminPanelController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserModel> _userManager;

        public AdminPanelController(RoleManager<IdentityRole> roleManager,
            UserManager<UserModel> userManager,
            ApplicationDBContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var Roles = _roleManager.Roles.ToList();
            return Ok(Roles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(String RoleName)
        {
            var IsRoleExist = await _roleManager.RoleExistsAsync(RoleName); 
            if (!IsRoleExist)
            {
                var Result = await _roleManager.CreateAsync(new IdentityRole(RoleName));
                if (Result.Succeeded)
                {
                    return Ok(new {result = $"Role {RoleName} added successfully"});
                }
                else
                {
                    return BadRequest(new {error = $"Something went wrong adding {RoleName} role"});
                }
            }
            return BadRequest(new {error = "Role already exist!"});

        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var Users = await _userManager.Users.ToListAsync();

            return Ok(Users);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string Email, string RoleName)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if (User != null) {
            var Result = await _userManager.AddToRoleAsync(User, RoleName); 
                if (Result.Succeeded)
                {
                    return Ok(new { result = $"User {User.UserName} added to the {RoleName} role" });
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to add user {User.UserName} to the {RoleName} role" });
                }
            }
            return BadRequest(new { error = "Unable to find user" });

        }
        [HttpGet]
        public async Task<IActionResult> GetUserRoles(String Email)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            var UserRoles = await _userManager.GetRolesAsync(User);
            return Ok(UserRoles);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(String Email, String RoleName)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if (User != null)
            {
                var Result = await _userManager.RemoveFromRoleAsync(User, RoleName);
                if (Result.Succeeded)
                {
                    return Ok(new { result = $"User {User.Email} removed from the {RoleName} role" });

                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to removed user {User.Email} from the {RoleName} role" });

                }
            }
            return BadRequest(new { error = "Unable to find user" });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(String RoleName)
        {
            var Role = await _roleManager.FindByNameAsync(RoleName);    
            if (Role != null)
            {
                var Result = await _roleManager.DeleteAsync(Role);  
            if (Result.Succeeded)
                {
                    return Ok(new { result = $"Role deleted successfully." });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = $"Something went wrong deleting {RoleName} Role."
                    });
                }
            }
            return BadRequest(new { error = $"{RoleName} not found!"});
           
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersInRole(String RoleName)
        {
            var Role = await _roleManager.FindByNameAsync(RoleName);
            if (Role == null)
            {
                return NotFound("Role not found.");
            }

            var Users = await _userManager.GetUsersInRoleAsync(RoleName);
            return Ok(Users);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClaims(String Email)
        {
            var User = await _userManager.FindByEmailAsync(Email);

            var Claims = await _userManager.GetClaimsAsync(User);

            return Ok(Claims);
        }

        [HttpPost]
        public async Task<IActionResult> AddClaimToUser(String Email, string ClaimName, string Value)
        {
            var User = await _userManager.FindByEmailAsync(Email);

            var UserClaim = new Claim(ClaimName, Value);

            if (User != null)
            {
                var Result = await _userManager.AddClaimAsync(User, UserClaim);

                if (Result.Succeeded)
                {
                    return Ok(new { result = $"the claim {ClaimName} add to the  User {User.Email}" });
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to add the claim {ClaimName} to the  User {User.Email}" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }
    }
}
