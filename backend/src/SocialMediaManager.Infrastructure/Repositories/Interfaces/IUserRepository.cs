using SocialMediaManager.Domain.Models;

namespace SocialMediaManager.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task GetUsers();
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByEmail(string email);
}