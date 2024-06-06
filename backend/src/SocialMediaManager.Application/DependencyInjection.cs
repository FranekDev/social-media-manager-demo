using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialMediaManager.Application.Services;
using SocialMediaManager.Application.Services.Instagram;
using SocialMediaManager.Application.Services.Interfaces;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models;
using SocialMediaManager.Infrastructure.Database;

namespace SocialMediaManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationAndJwtBearer(this IServiceCollection services, IConfiguration configuration)
    {
        var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = 
            options.DefaultChallengeScheme = 
            options.DefaultForbidScheme = 
            options.DefaultScheme = 
            options.DefaultSignInScheme = 
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                )
            };
        });
        
        return services;
    }
    
    public static IServiceCollection AddIdentityAndEntityFrameworkStores(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<AppDbContext>();
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IInstagramAuthService, InstagramAuthService>();
        services.AddScoped<IInstagramUserService, InstagramUserService>();
        services.AddScoped<IInstagramContentService, InstagramContentService>();
        services.AddScoped<ISchedulerService, SchedulerService>();
        services.AddScoped<IInstagramScheduledPostService, InstagramScheduledPostService>();
        
        return services;
    }
}