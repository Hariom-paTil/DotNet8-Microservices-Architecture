using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Services.AuthAPI.Data;
using Services.AuthAPI.Model;
using Services.AuthAPI.Model.DTO;
using System.Security.Cryptography.Xml;

namespace Services.AuthAPI.Service.IService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator,
            AppDbContext appDbContext,
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToUpper() == email.ToUpper());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }

        public async Task<LoginResponceDto> Login(LoginRequestDto loginDto)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == loginDto.UserName);
            bool isValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (user == null || !isValid)
            {
                return new LoginResponceDto
                {
                    User = null,
                    Token = null
                };
            }


            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user,roles);

            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Name = user.name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponceDto loginResponce = new LoginResponceDto()
            {
                User = userDTO,
                Token = token
            };

            return loginResponce;
        }

          

        public async Task<string> RegisterAsync(RegisterationRequestDTO registerDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                NormalizedEmail = registerDto.Email.ToUpper(),
                name = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber

            };
            try
            {
             
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if(result.Succeeded)
                {
                    var userToReturn =  _appDbContext.ApplicationUsers.First(u => u.UserName == registerDto.Email);

                    UserDTO userDTO = new UserDTO()
                    {
                        Id = userToReturn.Id,
                        Name = userToReturn.name,
                        Email = userToReturn.Email,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return "Error occurred during registration.";

        }
    }
}
