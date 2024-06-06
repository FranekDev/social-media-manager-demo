namespace SocialMediaManager.Application.Services.Interfaces.Instagram;

public interface IInstagramAuthService
{
    Task<string?> GetLongLiveToken(string accessToken);
}