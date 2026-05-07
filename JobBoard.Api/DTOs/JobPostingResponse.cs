namespace JobBoard.Api.DTOs;

public class JobPostingResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
}