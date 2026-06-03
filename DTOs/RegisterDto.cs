namespace WebApplication1.DTOs;

public class RegisterDto
{
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}