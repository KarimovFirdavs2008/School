using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]

public class JournalController: ControllerBase
{
    private readonly IJournalService _service;
    public JournalController(IJournalService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetJournal()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJournal(int id)
    {
        var journal = await _service.GetByIdAsync(id);
        return Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJournal(CreateJournalDto dto)
    {
        var journal = await _service.CreateAsync(dto);
        return Ok(journal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJournal(int id, UpdateJournalDto dto)
    {
        var journal = await _service.UpdateAsync(id, dto);
        return Ok(journal);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJournal(int id)
    {
        var journal = await _service.DeleteAsync(id);
        return Ok(journal);
    }
}