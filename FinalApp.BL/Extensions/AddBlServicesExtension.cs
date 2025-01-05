using System.Reflection;
using System.Text;
using FinalApp.BL.ExternalServices.Abstractions;
using FinalApp.BL.ExternalServices.Implementations;
using FinalApp.BL.Profiles.IdentityProfiles;
using FinalApp.BL.Services.Abstractions;
using FinalApp.BL.Services.Implementations;
using FinalApp.Core.Entities.Identity;
using FinalApp.DAL.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinalApp.BL.Extensions;

public static class AddBlServicesExtension
{
    public static void AddBlServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(IdentityProfile));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        
        services.AddAuthentication(cfg => {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
        }).AddJwtBearer(x => {

            x.TokenValidationParameters = new TokenValidationParameters
            {
        
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8
                        .GetBytes(configuration["Jwt:SecretKey"])
                ),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration["Jwt:Audience"],
                ValidIssuer = configuration["Jwt:Issuer"]
            };
        });
        
        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 4;
            }
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<FinalAppDbContext>();
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>(); 
        services.AddScoped<ISizeService, SizeService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IIdentityService, IdentityService>();
       
        
        services.AddScoped<IEmailService, EmailService>(); 
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IFileService, FileService>();
    }
}