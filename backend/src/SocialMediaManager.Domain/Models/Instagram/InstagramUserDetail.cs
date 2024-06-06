using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramUserDetail
{
    public int Id { get; set; }
    public User User { get; set; }
    public string InstagramUser { get; set; }
    public string AccessToken { get; set; }
};