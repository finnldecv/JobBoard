using System.ComponentModel.DataAnnotations;

namespace JobBoard.Api.DTOs;

public class LoginRequest
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}