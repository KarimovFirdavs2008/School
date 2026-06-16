using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface IJournalRepository
{
    Task<List<Journal>> GetAllAsync();
    Task<Journal?> GetByIdAsync(int id);
    Task<Journal> CreateAsync(Journal journal);
    Task<Journal?> UpdateAsync(int id, Journal journal);
    Task<bool> DeleteAsync(int id);
}