using Newtonsoft.Json;

namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramLongLivedToken
{
    [JsonProperty("access_token")]
    public string AccessToken { get; init; }
    [JsonProperty("token_type")]
    public string TokenType { get; init; }
};