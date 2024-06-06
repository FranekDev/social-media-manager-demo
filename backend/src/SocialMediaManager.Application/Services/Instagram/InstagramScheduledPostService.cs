using System.Globalization;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;
using SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

namespace SocialMediaManager.Application.Services.Instagram;

public class InstagramScheduledPostService(IInstagramScheduledPostRepository scheduledPostRepository)
: IInstagramScheduledPostService
{
    private readonly IInstagramScheduledPostRepository _scheduledPostRepository = scheduledPostRepository;

    public async Task<IEnumerable<InstagramScheduledPostContent>> GetScheduledPosts(string igUserId)
    {
        var posts = await _scheduledPostRepository.GetScheduledPosts();
        return MapPostToPostContent(posts);
    }

    public async Task<IEnumerable<InstagramScheduledPostContent>> GetUnpublishedPosts(string igUserId)
    {
        var posts = await _scheduledPostRepository.GetScheduledPosts();
        var unPublishedPosts = posts.Where(p => !p.IsPublished);
        return MapPostToPostContent(unPublishedPosts);
    }

    private string FormatDate(string date)
    {
        var publishDate = DateTime.ParseExact(date, "yyyy-MM-ddTHH:mm:ss.fffZ",
            CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).AddDays(1);

        return publishDate.ToString("G");
    }

    private IEnumerable<InstagramScheduledPostContent> MapPostToPostContent(IEnumerable<InstagramScheduledPost> posts)
    {
        return posts.Select(p => 
            new InstagramScheduledPostContent
            {
                Caption = p.Caption,
                ImageUrl = p.ImageUrl,
                IgUserId = p.IgUserId,
                CreationId = p.CreationId,
                IsPublished = p.IsPublished,
                PublishDate = FormatDate($"{p.PublishDate}T{p.PublishTime}")
            }
        );
    }
}