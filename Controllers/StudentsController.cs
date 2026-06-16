using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;



namespace WebApplication1.Controllers;
[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _service.GetByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
    {
        var student = await _service.CreateAsync(dto);
        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
    {
        var student = await _service.UpdateAsync(id, dto);
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _service.DeleteAsync(id);
        return Ok(student);
    }
}