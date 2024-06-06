using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Interfaces.Instagram;

public interface IInstagramScheduledPostService
{
    Task<IEnumerable<InstagramScheduledPostContent>> GetScheduledPosts(string igUserId);
    Task<IEnumerable<InstagramScheduledPostContent>> GetUnpublishedPosts(string igUserId);
}