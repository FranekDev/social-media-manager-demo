namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramScheduledPost
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string Caption { get; set; }
    public string PublishTime { get; set; }
    public string PublishDate { get; set; }
    public string IgUserId { get; set; }
    public string UserId { get; set; }
    public string? CreationId { get; set; }
    public bool IsPublished { get; set; } = false;
};