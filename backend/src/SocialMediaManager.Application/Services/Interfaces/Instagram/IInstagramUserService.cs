using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Interfaces.Instagram;

public interface IInstagramUserService
{
    Task<InstagramUser?> GetUserData(string igUserId);
    Task<InstagramUser?> GetUserByEmail(string email);
    Task SaveUserDetail(InstagramUserDetail userDetail);
}