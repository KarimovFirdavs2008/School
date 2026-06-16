using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task<Teacher> CreateAsync(Teacher teacher);
    Task<Teacher?> UpdateAsync(int id, Teacher teacher);
    Task<bool> DeleteAsync(int id);
}