namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramScheduledPostContent
{
    public string Caption { get; init; }
    public string ImageUrl { get; init; }
    public string IgUserId { get; init; }
    public string? CreationId { get; init; }
    public bool IsPublished { get; init; }
    public string PublishDate { get; init; }
};