using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.Auth;
using FrontEnd.WebPage.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FrontEnd.WebPage.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
    

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);
           
            if (responseDto != null && responseDto.IsSuccess)
            {
                // This Line store Converted Object to LoginResponceDto 
                //
                LoginResponceDto loginResponceDto = JsonConvert.DeserializeObject<LoginResponceDto>(Convert.ToString(responseDto.Result));
                
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(loginRequestDto);
            }
            
         
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDTO registerationRequestDTO)
        {
           ResponseDto result= await _authService.RegisterAsync(registerationRequestDTO);
            ResponseDto assighRole;
            if(result != null && result.IsSuccess)
            {

                if (string.IsNullOrEmpty(registerationRequestDTO.Role))
                {
                    registerationRequestDTO.Role = SD.RoleCustomer;
                }
                assighRole = await _authService.AssignRoleAsync(registerationRequestDTO);
                if (assighRole != null && assighRole.IsSuccess)
                {
                    TempData["success"] = "User Registered Successfully";
                    return RedirectToAction(nameof(Login));

                }

            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View(registerationRequestDTO);
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
