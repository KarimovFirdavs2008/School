using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface ITeacherService
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task<Teacher> CreateAsync(CreateTeacherDto dto);
    Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto dto);
    Task<bool> DeleteAsync(int id);
}