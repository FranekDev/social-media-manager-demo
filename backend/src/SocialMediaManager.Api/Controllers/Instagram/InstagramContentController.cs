using Microsoft.AspNetCore.Mvc;
using SocialMediaManager.Application.Services.Interfaces;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Api.Controllers.Instagram;

[ApiController]
[Route("api/[controller]")]
public class InstagramContentController(
    IInstagramUserService userService, 
    IInstagramContentService contentService,
    ISchedulerService schedulerService
) : ControllerBase
{
    private readonly IInstagramUserService _userService = userService;
    private readonly IInstagramContentService _contentService = contentService;
    private readonly ISchedulerService _schedulerService = schedulerService;
    
    [HttpPost("publish")]
    public async Task<IActionResult> Publish([FromBody] InstagramPost post)
    {
        try
        {
            await _schedulerService.SchedulePost(post);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}