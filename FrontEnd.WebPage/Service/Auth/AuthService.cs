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
            // If you check SendAsync method have two parameters, one is RequestDto and another is withBearerToken, so we can use it to send the request to the API.
            //  but we passed single but steel the method working because the second parameter is optional and default value is true, so we can use it to send the request to the API.
            // in C# if we have a method with optional parameters, we can call the method with only the required parameters and the optional parameters will take their default values.
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
            }, withBearerToken: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDTO registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBase + "/api/auth/register",
                Data = registerationRequestDto
            }, withBearerToken: false);
        }
    }
    
}
