using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class JournalService : IJournalService
{
    private readonly IJournalRepository _repository;
    public JournalService(IJournalRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Journal>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<Journal?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Journal> CreateAsync(CreateJournalDto dto)
    {
        var journal = new Journal
        {
            TeacherName = dto.TeacherName,
            StudentName = dto.StudentName,
            LessonName = dto.LessonName,
            Points = dto.Points,
            DateCreated = dto.DateCreated,
            ClassId = dto.ClassId
        };
        return await _repository.CreateAsync(journal);
    }

    public async Task<Journal?> UpdateAsync(int id, UpdateJournalDto dto)
    {
        var journal = await _repository.GetByIdAsync(id);
        if (journal == null)
            return null;
        
        journal.TeacherName = dto.TeacherName;
        journal.StudentName = dto.StudentName;
        journal.LessonName = dto.LessonName;
        journal.Points = dto.Points;
        journal.DateCreated = dto.DateCreated;
        journal.ClassId = dto.ClassId;
        return await _repository.UpdateAsync(id, journal);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}