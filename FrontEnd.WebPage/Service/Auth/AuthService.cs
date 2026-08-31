using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.IService;
using static FrontEnd.WebPage.Utility.SD;

namespace FrontEnd.WebPage.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> AssignRoleAsync(RegisterationRequestDTO registerationRequestDTO)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBase + "/api/auth/AssignRole",
                Data = registerationRequestDTO
            });
        }

        public async Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBase + "/api/auth/login",
                Data = loginRequestDto
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDTO registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBase + "/api/auth/register",
                Data = registerationRequestDto
            });
        }
    }
    
}
