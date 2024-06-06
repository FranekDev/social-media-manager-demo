using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Interfaces;

public interface ISchedulerService
{
    Task SchedulePost(InstagramPost post);
}