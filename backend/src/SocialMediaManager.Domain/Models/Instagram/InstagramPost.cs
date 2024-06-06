using System.ComponentModel.DataAnnotations;

namespace SocialMediaManager.Domain.Models.Instagram;

public record InstagramPost
{
    [Required]
    public string ImageUrl { get; init; }
    
    [Required]
    public string Caption { get; init; }
    
    [Required]
    public string PublishTime { get; init; }
    
    [Required]
    public string PublishDate { get; init; }
    
    [Required]
    public string IgUserId { get; init; }

    public string UserEmail { get; set; } = "";
};