using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers;
[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _db;

    public StudentsController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _db.Students
            .Include(s => s.Class)
            .ToListAsync();

        return Ok(students);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _db.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == id);
        return Ok(student);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
    {
        var student = new Student()
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Age = dto.Age,
            Phone = dto.Phone,
            Address = dto.Address,
            ClassId = dto.ClassId
        };
        _db.Students.Add(student);
        await _db.SaveChangesAsync();
        return Ok(student);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
    {
        var student = await _db.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound("Student not found");
        }
        student.Name = dto.Name;
        student.Surname = dto.Surname;
        student.Age = dto.Age;
        student.Phone = dto.Phone;
        student.Address = dto.Address;
        student.ClassId = dto.ClassId;

        await _db.SaveChangesAsync();
        return Ok(student);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _db.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound("Student not found");
        }

        _db.Students.Remove(student);

        await _db.SaveChangesAsync();

        return Ok(student);
    }
}