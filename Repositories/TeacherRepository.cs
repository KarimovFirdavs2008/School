using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _db;

    public TeacherRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<List<Teacher>> GetAllAsync()
    {
        return _db.Teachers.ToListAsync();
    }

    public Task<Teacher?> GetByIdAsync(int id)
    {
        return  _db.Teachers.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Teacher> CreateAsync(Teacher teacher)
    {
        _db.Teachers.Add(teacher);
        await _db.SaveChangesAsync();
        return teacher;
    }

    public async Task<Teacher?> UpdateAsync(int id, Teacher teacher)
    {
        await _db.SaveChangesAsync();
        return teacher;
    }
    

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await _db.Teachers.FindAsync(id);
        if (teacher == null)
            return false;
        _db.Teachers.Remove(teacher);
        await _db.SaveChangesAsync();
        return true;
    }
}