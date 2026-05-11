namespace JobBoard.Api.DTOs;

public class JobQueryParameters
{
    public string? SearchTerm { get; set; }
    public int Page { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > 50) ? 50 : value;
    }
}