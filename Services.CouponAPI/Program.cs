using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.CouponAPI;
using Services.CouponAPI.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();   
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var secret= builder.Configuration.GetValue<string>("ApiSettings:SecretKey");
var issurer= builder.Configuration.GetValue<string>("ApiSettings:Issuer");
var audience= builder.Configuration.GetValue<string>("ApiSettings:Audience");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// This code configures JWT authentication for the application.
// It retrieves the secret key, issuer, and audience from the configuration settings and sets up the authentication scheme to use JWT Bearer tokens.
// The token validation parameters are defined to ensure that the tokens are valid, including checking the signing key, issuer, and audience.
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

builder.Services.AddAuthorization();















var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ApplyMigaration(); // Apply any pending migrations to the database when the application starts.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



// This method is used to apply any pending migrations to the
// database when the application starts.
void ApplyMigaration()
{

    using(var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}
