using Services.AuthAPI.Model.DTO;

namespace Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterationRequestDTO registerDto);
        Task<LoginResponceDto> Login(LoginRequestDto loginDto);

        Task<bool> AssignRole(string email, string roleName);
    }
}
