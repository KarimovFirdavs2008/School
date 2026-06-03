using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]

public class TeacherController: ControllerBase
{
    private readonly AppDbContext _db;
    public TeacherController(AppDbContext db)
    {
        _db = db;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetTeacher()
    {
        var teachers = await _db.Teachers.ToListAsync();
        return Ok(teachers);
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
        var teacher = await _db.Teachers
            .FirstOrDefaultAsync(s => s.Id == id);
        return Ok(teacher);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeacher(CreateTeacherDto dto)
    {
        var teacher = new Teacher
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Age = dto.Age,
            Phone = dto.Phone,
            Address = dto.Address,
            Lesson = dto.Lesson,
            Experience = dto.Experience,
            Salary = dto.Salary
        };
        _db.Teachers.Add(teacher);
        await _db.SaveChangesAsync();
        return Ok(teacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherDto dto)
    {
        var teacher = await _db.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound("Teacher not found");
        }
        teacher.Name = dto.Name;
        teacher.Surname = dto.Surname;
        teacher.Age = dto.Age;
        teacher.Phone = dto.Phone;
        teacher.Address = dto.Address;
        teacher.Lesson = dto.Lesson;
        teacher.Experience = dto.Experience;
        teacher.Salary = dto.Salary;

        await _db.SaveChangesAsync();
        return Ok(teacher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _db.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound("Teacher not found");
        }
        _db.Teachers.Remove(teacher);
        await _db.SaveChangesAsync();
        return Ok(teacher);
    }
}