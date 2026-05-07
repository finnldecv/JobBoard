using System.ComponentModel.DataAnnotations;

namespace JobBoard.Api.DTOs;

public class CreateJobPostingRequest
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? Location { get; set; }
}