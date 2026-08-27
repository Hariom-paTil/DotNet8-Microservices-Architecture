using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {

        [HttpPost("register")]
        public IActionResult Register()
        {
           
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok("User logged in successfully.");
        }
    }
}
