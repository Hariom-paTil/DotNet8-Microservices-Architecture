using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.ProductAPI;
using Services.ProductAPI.Data;
using Services.ProductAPI.Extension;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Its used when you want to add authorization in your swagger UI. It will add a lock button in the swagger
// UI which will allow you to enter the JWT token and authorize the requests.
// This code configures Swagger to include a security definition for JWT Bearer tokens, allowing users to enter their JWT token in the Swagger UI for authorized requests.
// So you can test your API endpoints that require authentication directly from the Swagger UI by providing a valid JWT token.
builder.Services.AddSwaggerGen(option => {

    option.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Description = "Enter the following JWT token in the format: Bearer {your token}"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });

});





builder.AddAppAuthentication(); // This is the extension method which is defined in the WebApplicationBuilderExtension.cs file. It will add the JWT authentication to the application.

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
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}
