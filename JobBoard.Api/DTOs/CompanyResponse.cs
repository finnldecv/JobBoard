namespace JobBoard.Api.DTOs;

public class CompanyResponse
{
    public Guid Id {get;set;}
    public string Name {get; set;} = string.Empty;
    public string? WebsiteUrl {get; set;} 
}