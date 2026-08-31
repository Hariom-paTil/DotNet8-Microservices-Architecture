using FrontEnd.WebPage.Models;

namespace FrontEnd.WebPage.Service.Auth
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto> RegisterAsync(RegisterationRequestDTO registerationRequestDto);

        Task<ResponseDto> AssignRoleAsync(RegisterationRequestDTO registerationRequestDTO);
    }
}
