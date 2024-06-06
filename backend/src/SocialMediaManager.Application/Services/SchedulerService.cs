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
        var date = DateTime.Parse(post.PublishDate);
        var time = DateTime.Parse(post.PublishTime);
        var postPublishDate = string.Join('T', date, time);
        var dateTimeString = $"{post.PublishDate}T{post.PublishTime}";
        var publishDate = DateTime.ParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).AddDays(1);
        var delay = publishDate - DateTime.Now;
        
        var container = await _contentService.GetContainerId(post, post.IgUserId);

        if (container?.Id is not null)
        {
            BackgroundJob.Schedule<IInstagramContentService>(x => 
                x.PublishContainer(container.Id, post.IgUserId), delay);
        }
    }
}