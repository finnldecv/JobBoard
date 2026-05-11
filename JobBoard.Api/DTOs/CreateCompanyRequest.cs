namespace JobBoard.Api.DTOs;

public class CreateCompanyRequest
{
    public string Name { get; set; } = string.Empty;
    public string? WebsiteUrl { get; set; }
}