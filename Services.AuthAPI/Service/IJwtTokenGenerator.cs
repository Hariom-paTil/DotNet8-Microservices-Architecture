using Services.AuthAPI.Model;

namespace Services.AuthAPI.Service
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
