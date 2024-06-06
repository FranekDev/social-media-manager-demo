using SocialMediaManager.Domain.Models;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

public interface IInstagramUserRepository
{
    Task Add(InstagramUserDetail user);
    Task<InstagramUserDetail?> GetUserDetailByInstagramUser(User user);
}