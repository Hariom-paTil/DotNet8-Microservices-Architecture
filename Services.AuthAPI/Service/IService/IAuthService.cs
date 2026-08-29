using Services.AuthAPI.Model.DTO;

namespace Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegisterationRequestDTO registerDto);
        Task<LoginRequestDto> Login(LoginRequestDto loginDto);
    }
}
