using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Interfaces.Instagram;

public interface IInstagramContentService
{
    Task<InstagramContainer?> GetContainerId(InstagramPost post, string igUserId);


    Task<string?> PublishContainer(string creationId, string igUserId);
}