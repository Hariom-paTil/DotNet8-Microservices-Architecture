using FrontEnd.WebPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.WebPage.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterationRequestDTO registerationRequestDTO = new RegisterationRequestDTO();
            return View(registerationRequestDTO);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
