using System.ComponentModel.DataAnnotations;

namespace JobBoard.Api.Models;

public class JobPosting
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}