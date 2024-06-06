using Microsoft.AspNetCore.Mvc;
using SocialMediaManager.Application.Services.Instagram;
using SocialMediaManager.Application.Services.Interfaces.Instagram;
using SocialMediaManager.Domain.Models.Instagram;

namespace SocialMediaManager.Api.Controllers.Instagram;

[ApiController]
[Route("api/[controller]")]
public class InstagramUserController(IInstagramUserService userService) : ControllerBase
{
    private readonly IInstagramUserService _userService = userService;

    [HttpGet("about/{igUserId}")]
    public async Task<IActionResult> About(string igUserId)
    {
        var user = await _userService.GetUserData(igUserId);

        if (user is null)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> SaveUserDetail([FromBody] InstagramUserDetail userDetail)
    {
        await _userService.SaveUserDetail(userDetail);
        return Created();
    }
}