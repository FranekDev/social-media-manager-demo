using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;

namespace SocialMediaManager.Application.Services.Instagram;

public class InstagramUserService(HttpClient httpClient, IUserRepository userRepository, IConfiguration configuration) : IInstagramUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly string _baseUrl = "https://graph.facebook.com/v20.0";
    private readonly HttpClient _httpClient = httpClient;

    public async Task<InstagramUser?> GetUserData(string igUserId)
    {
        var accessToken = _configuration.GetValue<string>("Instagram:AccessToken");
        var fields = new List<string> { "username", "media_count", "followers_count" };
        var url = $"{_baseUrl}/{igUserId}?fields={string.Join(",", fields)}&access_token={accessToken}";
        var response = await _httpClient.GetFromJsonAsync<InstagramUser>(url);
        return response;
    }

    public Task SaveUserDetail(InstagramUserDetail userDetail)
    {
        throw new NotImplementedException();
    }

    public async Task<InstagramUser?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}