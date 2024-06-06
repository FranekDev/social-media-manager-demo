using System.Text.Json.Serialization;

namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramUser
{
    public string UserName { get; init; }
    
    [JsonPropertyName("followers_count")]
    public int Followers { get; init; }
    
    [JsonPropertyName("media_count")]
    public int MediaCount { get; init; }
    
    public string Id { get; init; }
}