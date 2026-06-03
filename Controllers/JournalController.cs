using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]

public class JournalController: ControllerBase
{
    private readonly AppDbContext _db;
    public JournalController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetJournal()
    {
        var  journal = await _db.Journals.ToListAsync();
        return Ok(journal);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJournal(int id)
    {
        var journal = await _db.Journals
            .FirstOrDefaultAsync(s => s.Id == id);
        return Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJournal(CreateJournalDto dto)
    {
        var journal = new Journal
        {
            TeacherName =  dto.TeacherName,
            StudentName = dto.StudentName,
            LessonName = dto.LessonName,
            Points = dto.Points,
            DateCreated =  dto.DateCreated,
            ClassId =  dto.ClassId
        };
        _db.Journals.Add(journal);
        await _db.SaveChangesAsync();
        return Ok(journal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJournal(int id, UpdateJournalDto dto)
    {
        var journal = await _db.Journals.FindAsync();
        if (journal == null)
        {
            return NotFound("Journal not found");
        }

        journal.TeacherName = dto.TeacherName;
        journal.StudentName = dto.StudentName;
        journal.LessonName = dto.LessonName;
        journal.Points = dto.Points;
        journal.DateCreated = dto.DateCreated;
        journal.ClassId = dto.ClassId;
        
        await _db.SaveChangesAsync();
        return Ok(journal);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJournal(int id)
    {
        var journal = await _db.Journals.FindAsync(id);
        if (journal == null)
        {
            return NotFound("Journal not found");
        }
        _db.Journals.Remove(journal);
        await _db.SaveChangesAsync();
        return Ok(journal);
    }
}