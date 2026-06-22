using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface ICleanerRepository
{
    Task<List<Cleaner>> GetAllAsync();
    Task<Cleaner?> GetByIdAsync(int id);
    Task<Cleaner> CreateAsync(Cleaner cleaner);
    Task<Cleaner?> UpdateAsync(int id, Cleaner cleaner);
    Task<bool> DeleteAsync(int id);
}