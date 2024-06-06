using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Api.Controllers.Instagram;

[ApiController]
[Route("api/[controller]")]
public class InstagramAuthController(IInstagramAuthService authService) : ControllerBase
{
    private readonly IInstagramAuthService _authService = authService;
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] InstagramShortLivedToken token)
    {
        try
        {
            var longLiveToken = await _authService.GetLongLiveToken(token.AccessToken);

            if (longLiveToken is null)
            {
                return BadRequest();
            }

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string token)
    {
        try
        {
            var longLiveToken = await _authService.GetLongLiveToken(token);

            if (longLiveToken is null)
            {
                return BadRequest();
            }

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}