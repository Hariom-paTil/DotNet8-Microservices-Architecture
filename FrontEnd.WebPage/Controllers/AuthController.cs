using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.Auth;
using FrontEnd.WebPage.Service.TokenProviderService;
using FrontEnd.WebPage.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FrontEnd.WebPage.Controllers
{
    public class AuthController : Controller
    {
     
        private readonly ITokenProvider _tokenProvider;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
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


                await LoginUser(loginResponceDto);
                _tokenProvider.SetToken(loginResponceDto.Token);

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

        private async Task LoginUser(LoginResponceDto model)
        {
            // This is the inbuild class which will help us to
            // read the token and convert it into claims identity
            var handle = new JwtSecurityTokenHandler();


            var jwt= handle.ReadJwtToken(model.Token);


            //CookieAuthenticationDefaults.AuthenticationScheme tells .NET that this identity was authenticated using cookies.
            //This is crucial: if you don't provide an authentication scheme, the identity will be treated as unauthenticated.

            var identity =new ClaimsIdentity(jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme);


            //These lines are manually searching the parsed JWT for specific claims (Email, Sub/User ID, and Name)
            //and explicitly adding them back into the identity using modern JsonWebTokens constant names.
            identity.AddClaim(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(c => c.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(c => c.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub).Value));

            identity.AddClaim(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(c => c.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
     jwt.Claims.FirstOrDefault(c => c.Type == Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email).Value));

            var principal = new ClaimsPrincipal(identity);

            //SignInAsync()	This is the actual "login" trigger. It takes the digital wallet,
            //encrypts it, and saves it to the user's web browser as a cookie.
            //This tells the website the user is officially logged in.
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
