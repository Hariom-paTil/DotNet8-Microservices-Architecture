using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Services.AuthAPI.Data;
using Services.AuthAPI.Model;
using Services.AuthAPI.Model.DTO;

namespace Services.AuthAPI.Service.IService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginRequestDto> Login(LoginRequestDto loginDto)
        {
            throw new NotImplementedException();
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
