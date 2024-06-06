using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Application.Services.Instagram;

public class InstagramAuthService(HttpClient httpClient, IConfiguration configuration) : IInstagramAuthService
{
    private readonly string BASE_URL = "https://graph.facebook.com/v20.0/oauth/access_token";
    private readonly string GRANT_TYPE = "fb_exchange_token";
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;
    
    public async Task<string?> GetLongLiveToken(string accessToken)
    {
        var clientId = _configuration.GetValue<string>("Instagram:AppId");
        var clientSecret = _configuration.GetValue<string>("Instagram:AppSecret");
        var url = $"{BASE_URL}?grant_type={GRANT_TYPE}&client_id={clientId}&client_secret={clientSecret}&fb_exchange_token={accessToken}";
        var response = await _httpClient.GetFromJsonAsync<InstagramLongLivedToken>(url);
        return response?.AccessToken;
    }
}