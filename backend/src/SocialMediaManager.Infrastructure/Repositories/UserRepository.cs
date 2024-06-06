using Microsoft.EntityFrameworkCore;
using SocialMediaManager.Domain.Models;
using SocialMediaManager.Infrastructure.Database;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;

namespace SocialMediaManager.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<User> _dbSet = context.Set<User>();
    
    public Task GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}