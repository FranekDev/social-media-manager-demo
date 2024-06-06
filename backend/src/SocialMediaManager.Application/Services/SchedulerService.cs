using System.Globalization;
using Hangfire;
using SocialMediaManager.Application.Services.Interfaces;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services;

public class SchedulerService(IInstagramContentService contentService) : ISchedulerService
{
    private readonly IInstagramContentService _contentService = contentService;
    
    public async Task SchedulePost(InstagramPost post)
    {
        var delay = GetPublishDate(post.PublishDate, post.PublishTime) - DateTime.Now;
        var container = await _contentService.GetContainerId(post, post.IgUserId);

        if (container?.Id is not null)
        {
            BackgroundJob.Schedule<IInstagramContentService>(x => 
                x.PublishContainer(container.Id, post.IgUserId), delay);
        }
    }
    
    private DateTime GetPublishDate(string publishDate, string publishTime)
    {
        var dateTimeString = $"{publishDate}T{publishTime}";
        return DateTime.ParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).AddDays(1);
    }
}