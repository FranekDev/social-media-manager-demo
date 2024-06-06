using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Interfaces.Instagram;

public interface IInstagramScheduledPostService
{
    Task<IEnumerable<InstagramScheduledPostContent>> GetScheduledPosts();
    Task<IEnumerable<InstagramScheduledPostContent>> GetUnpublishedPosts();
}