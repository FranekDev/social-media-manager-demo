namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramShortLivedToken
{
    public string UserEmail { get; init; }
    public string AccessToken { get; init; }
}