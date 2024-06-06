using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaManager.Domain.Models;
using SocialMediaManager.Infrastructure.Database;
using SocialMediaManager.Infrastructure.Repositories;
using SocialMediaManager.Infrastructure.Repositories.Instagram;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;
using SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

namespace SocialMediaManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IInstagramScheduledPostRepository, InstagramScheduledPostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}