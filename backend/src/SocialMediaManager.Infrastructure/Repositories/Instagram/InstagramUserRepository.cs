using Microsoft.EntityFrameworkCore;
using SocialMediaManager.Domain.Models;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Infrastructure.Database;
using SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

namespace SocialMediaManager.Infrastructure.Repositories.Instagram;

public class InstagramUserRepository(AppDbContext context) : IInstagramUserRepository
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<InstagramUserDetail> _dbSet = context.Set<InstagramUserDetail>();

    public async Task Add(InstagramUserDetail user)
    {
        await _dbSet.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<InstagramUserDetail?> GetUserDetailByInstagramUser(User user)
    {
        var userDetail = await _dbSet.FirstOrDefaultAsync(u => u.User == user);
        return userDetail;
    }
}