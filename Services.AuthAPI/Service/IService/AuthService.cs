using Microsoft.AspNetCore.Identity;
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

        public Task<UserDTO> Register(RegisterationRequestDTO registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
