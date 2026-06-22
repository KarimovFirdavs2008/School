using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface ICleanerService
{
    Task<List<Cleaner>> GetAllAsync();
    Task<Cleaner?> GetByIdAsync(int id);
    Task<Cleaner> CreateAsync(CreateCleanerDto dto);
    Task<Cleaner?> UpdateAsync(int id, CreateCleanerDto dto);
    Task<bool> DeleteAsync(int id);
}