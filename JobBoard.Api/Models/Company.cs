namespace JobBoard.Api.Models;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? WebsiteUrl { get; set; }
    public List<JobPosting> JobPostings { get; set; } = new();
}