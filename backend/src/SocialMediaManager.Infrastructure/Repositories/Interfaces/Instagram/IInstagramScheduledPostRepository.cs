using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

public interface IInstagramScheduledPostRepository
{
    Task Add(InstagramScheduledPost post);
    Task<IEnumerable<InstagramScheduledPost>> GetScheduledPosts();
    Task<InstagramScheduledPost> GetScheduledPost(int id);
    Task Update(InstagramScheduledPost post);
    Task Delete(InstagramScheduledPost post);
    Task SetAsPublished(InstagramScheduledPost post);
    Task<InstagramScheduledPost?> GetScheduledPostByCreationId(string id);
}