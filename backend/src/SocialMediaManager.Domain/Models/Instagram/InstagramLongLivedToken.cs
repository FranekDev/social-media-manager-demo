namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramLongLivedToken
{
    public string AccessToken { get; init; }
    public string TokenType { get; init; }
};