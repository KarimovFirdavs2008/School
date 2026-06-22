using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class CleanerController: ControllerBase
{
    private readonly ICleanerService _service;
    public CleanerController(ICleanerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCleaners()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCleaner(int id)
    {
        var cleaner = await _service.GetByIdAsync(id);
        return Ok(cleaner);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCleaner(CreateCleanerDto dto)
    {
        var cleaner = await _service.CreateAsync(dto);
        return Ok(cleaner);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCleaner(int id, CreateCleanerDto dto)
    {
        var cleaner = await _service.UpdateAsync(id, dto);
        if (cleaner == null) return NotFound();
        return Ok(cleaner);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCleaner(int id)
    {
        var cleaner = await _service.DeleteAsync(id);
        return Ok(cleaner);
    }
}