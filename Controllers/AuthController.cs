using Microsoft.AspNetCore.Mvc;
using WalkMyDog.Api.Data;
using WalkMyDog.Api.DTOs;
using WalkMyDog.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace WalkMyDog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        // 1. Проверяем, не занят ли Email
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Этот Email уже занят" });
        }

        // 2. Хэшируем пароль
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // 3. Создаем сущность
        var user = new User
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            FullName = request.FullName,
            CreatedAt = DateTime.UtcNow
        };

        // 4. Сохраняем в базу
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Пользователь успешно зарегистрирован!" });
    }
}