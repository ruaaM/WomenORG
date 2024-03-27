using WomenORG.DTOs;

namespace WomenORG.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDTO> RegiserAsync(RegisterDTO registerDTO);
        Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO);

    }
}
