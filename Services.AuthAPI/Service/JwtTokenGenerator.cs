using Microsoft.IdentityModel.Tokens;
using Services.AuthAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string GenerateToken(ApplicationUser applicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);


            // Clain is a piece of information about the user that is encoded in the token.
            // In this case, we are adding the user's email, id, and username as claims in the token.
            // this information can be used by the application to identify the user and authorize access to resources.

            var claims = new  List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                    new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience=_jwtOptions.Audience,
                Issuer=_jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
