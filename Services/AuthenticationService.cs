using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WomenORG.DTOs;
using WomenORG.Interfaces;
using WomenORG.Models;

namespace WomenORG.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            IConfiguration configuration ,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new AuthenticationResponseDTO
                {
                    Message = "No Data inserted!",
                    isSuccess = false,
                    ResponseCode = 400,
                };

            var UserinDB = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (UserinDB == null)
            {
                return new AuthenticationResponseDTO
                {
                    Message = "User not found!",
                    isSuccess = false,
                    ResponseCode = 404
                };
            }
           
            var result = await _signInManager.PasswordSignInAsync(UserinDB.UserName, loginDTO.Password, false, false);
            
            if (result.Succeeded)
            {
                var UserRoles = await _userManager.GetRolesAsync(UserinDB);
                var userClaims = await _userManager.GetClaimsAsync(UserinDB);
                var claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Email, loginDTO.Email),
                 new Claim(ClaimTypes.NameIdentifier, UserinDB.Id)

            };
                claims.AddRange(userClaims);
                foreach (var userRole in UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    var role = await _roleManager.FindByNameAsync(userRole);
                    if (role != null)
                    {
                        var roleClaims = await _roleManager.GetClaimsAsync(role);
                        foreach (Claim roleClaim in roleClaims)
                        {
                            claims.Add(roleClaim);
                        }
                    }
                }
                var TokenHandler = new JwtSecurityTokenHandler();
                byte[] TokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);


                var TokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(0.5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var Token = TokenHandler.CreateToken(TokenDescription);
                return new AuthenticationResponseDTO
                {
                    Message = TokenHandler.WriteToken(Token),
                    isSuccess = true,
                    ResponseCode = 200
                };

            }


            return new AuthenticationResponseDTO
            {
                Message = "something went wrong",
                isSuccess = false,
            };
        }

        public async Task<AuthenticationResponseDTO> RegiserAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
                throw new NullReferenceException("Register Dto is null");

            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return new AuthenticationResponseDTO
                {
                    Message = "Passwords doesnt match",
                    isSuccess = false,
                };
            }

            var user = new UserModel
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                return new AuthenticationResponseDTO
                {
                    Message = "user created successfully",
                    isSuccess = true,
                };
            }
            return new AuthenticationResponseDTO
            {
                Message = "user didn't create",
                isSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
    
}
