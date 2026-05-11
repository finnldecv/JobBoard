using System.ComponentModel.DataAnnotations;

namespace JobBoard.Api.DTOs;

public class CreateJobPostingRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public string? Location { get; set; }
    public Guid CompanyId {get; set;}
}