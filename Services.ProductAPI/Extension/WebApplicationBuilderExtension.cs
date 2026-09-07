using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace Services.ProductAPI.Extension
{

    // This code configures JWT authentication for the application.
    // It retrieves the secret key, issuer, and audience from the configuration settings and sets up the authentication scheme to use JWT Bearer tokens.
    // The token validation parameters are defined to ensure that the tokens are valid, including checking the signing key, issuer, and audience.

    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
        {
            var settingSection = builder.Configuration.GetSection("ApiSettings");

            var secret = settingSection.GetValue<string>("SecretKey");
            var issurer = settingSection.GetValue<string>("Issuer");
            var audience = settingSection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issurer,
                    ValidateAudience = true,
                    ValidAudience = audience
                };
            });

            return builder;
        }

    }
}
