using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.AuthAPI.Model.DTO;
using Services.AuthAPI.Service.IService;
using System.Threading.Tasks;

namespace Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected AuthResponceDto _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new AuthResponceDto();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO registerDto)
        {
            var errorMessage = await _authService.RegisterAsync(registerDto);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);

            }
            return Ok(_response);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            var loginResponse = await _authService.Login(loginDto);
            if (loginResponse == null || loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Invalid username or password.";
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterationRequestDTO model)
        {
            var roleAssign = await _authService.AssignRole(model.Email,model.Role.ToUpper());
            if (!roleAssign)
            {
                _response.IsSuccess = false;
                _response.Message = "Error Encounter";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
