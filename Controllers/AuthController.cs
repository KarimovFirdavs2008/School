using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly TokenService _tokenService;

    public AuthController(
        AppDbContext db,
        TokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var exists = await _db.Users
            .AnyAsync(x => x.Username == dto.Username);

        if (exists)
        {
            return BadRequest("User exists");
        }

        var user = new User
        {
            Username = dto.Username,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash),
            Role = "User"
        };
        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return Ok("Registered");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x =>
                x.Username == dto.Username);

        if (user == null)
        {
            return BadRequest("User not found");
        }

        var valid = BCrypt.Net.BCrypt.Verify(
            dto.PasswordHash,
            user.PasswordHash);

        if (!valid)
        {
            return BadRequest("Invalid password");
        }

        var token = _tokenService.CreateToken(user);

        return Ok(new
        {
            token
        });
    }
}