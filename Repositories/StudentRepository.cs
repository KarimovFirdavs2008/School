using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _db;

    public StudentRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _db.Students
            .Include(x => x.Class)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _db.Students
            .Include(x => x.Class)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> UpdateAsync(int id, Student student)
    {
        await _db.SaveChangesAsync();

        return student;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _db.Students.FindAsync(id);

        if (student == null)
            return false;

        _db.Students.Remove(student);

        await _db.SaveChangesAsync();

        return true;
    }
}