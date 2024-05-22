using SocialMediaManager.Domain.Models;

namespace SocialMediaManager.Application.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}