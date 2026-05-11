using System.ComponentModel.DataAnnotations;

namespace JobBoard.Api.Models;

public class JobPosting
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public string? Location { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CompanyId {get; set;}
    public Company? Company {get; set;}
}