using Microsoft.AspNetCore.Mvc;
using SocialMediaManager.Application.Services.Interfaces.Instagram;

namespace SocialMediaManager.Api.Controllers.Instagram;

[ApiController]
[Route("api/[controller]")]
public class InstagramScheduledPostController(IInstagramScheduledPostService scheduledPostService, IInstagramUserService userService) : ControllerBase
{
    private readonly IInstagramScheduledPostService _scheduledPostService = scheduledPostService;
    private readonly IInstagramUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetScheduledPosts()
    {
        var posts  = await _scheduledPostService.GetUnpublishedPosts();
        return Ok(posts);
    }
}
