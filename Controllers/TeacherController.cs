using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;


namespace WebApplication1.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class TeacherController: ControllerBase
{
    private readonly ITeacherService _service;
    public TeacherController(ITeacherService  service)
    {
        _service = service;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetTeacher()
    {
        return Ok(await _service.GetAllAsync());
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
        var teacher = await _service.GetByIdAsync(id);
            
        return Ok(teacher);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeacher(CreateTeacherDto dto)
    {
        var teacher = await _service.CreateAsync(dto);
        return Ok(teacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherDto dto)
    {
        var teacher = await _service.UpdateAsync(id, dto);
        if (teacher == null)
            return NotFound();
        return Ok(teacher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _service.DeleteAsync(id);
        return Ok(teacher);
    }
}