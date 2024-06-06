using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaManager.Domain.Models;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Domain.Roles;

namespace SocialMediaManager.Infrastructure.Database;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // var roles = new List<IdentityRole>
        // {
        //     new IdentityRole
        //     {
        //         Name = Role.Admin,
        //         NormalizedName = Role.Admin.ToUpper()
        //     },
        //     new IdentityRole
        //     {
        //         Name = Role.User,
        //         NormalizedName = Role.User.ToUpper()
        //     }
        // };
        // builder.Entity<IdentityRole>().HasData(roles);
    }
    
    public DbSet<InstagramScheduledPost> InstagramScheduledPosts { get; set; }
    public DbSet<InstagramUserDetail> InstagramUserDetails { get; set; }
}