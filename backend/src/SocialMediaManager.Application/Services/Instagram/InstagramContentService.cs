using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;
using SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

namespace SocialMediaManager.Application.Services.Instagram;

public class InstagramContentService(
    HttpClient httpClient ,
    IInstagramScheduledPostRepository postRepository,
    IUserRepository userRepository,
    IConfiguration configuration
) : IInstagramContentService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IInstagramScheduledPostRepository _postRepository = postRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly string BASE_URL = "https://graph.facebook.com/v20.0";

    public async Task<InstagramContainer?> GetContainerId(InstagramPost post, string igUserId)
    {
        var accessToken = _configuration.GetValue<string>("Instagram:AccessToken");
        var imageUrl = post.ImageUrl.Contains("drive.google.com") ? ConvertGoogleDriveLinkToDirectLink(post.ImageUrl) : post.ImageUrl;

        var url =
        $"{BASE_URL}/{igUserId}/media?image_url={imageUrl}&caption={post.Caption}&access_token={accessToken}";

        var response = await _httpClient.PostAsync(url, null);
        var content = await response.Content.ReadFromJsonAsync<InstagramContainer>();

        var user = await _userRepository.GetUserByEmail(post.UserEmail);
        
        await _postRepository.Add(new InstagramScheduledPost
        {
            ImageUrl = post.ImageUrl,
            Caption = post.Caption,
            PublishTime = post.PublishTime,
            PublishDate = post.PublishDate,
            IgUserId = post.IgUserId,
            UserId = user?.Id ?? "",
            CreationId = content?.Id,
        });
        
        return content;
    }

    public async Task<string?> PublishContainer(string creationId, string igUserId)
    {
        var accessToken = _configuration.GetValue<string>("Instagram:AccessToken");
        var url = $"{BASE_URL}/{igUserId}/media_publish?creation_id={creationId}&access_token={accessToken}";
        var response = await _httpClient.PostAsync(url, null);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return response?.StatusCode.ToString();
        }
        
        var postToUpdate = await _postRepository.GetScheduledPostByCreationId(creationId);

        if (postToUpdate is not null)
        {
            await _postRepository.SetAsPublished(postToUpdate);
        }

        return response?.StatusCode.ToString();
    }

    private string ConvertGoogleDriveLinkToDirectLink(string url)
    {
        var fileId = ExtractFileIdFromUrl(url);
        return $"https://drive.usercontent.google.com/download?id={fileId}";
    }

    private string ExtractFileIdFromUrl(string url)
    {
        var fileIdMarker = "/file/d/";
        var startIndex = url.IndexOf(fileIdMarker) + fileIdMarker.Length;
        var endIndex = url.IndexOf('/', startIndex);

        if (endIndex == -1)
        {
            endIndex = url.Length;
        }

        var fileId = url.Substring(startIndex, endIndex - startIndex);
        return fileId;
    }
}