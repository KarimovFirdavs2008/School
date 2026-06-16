using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IJournalService
{
    Task<List<Journal>> GetAllAsync();
    Task<Journal?> GetByIdAsync(int id);
    Task<Journal> CreateAsync(CreateJournalDto dto);
    Task<Journal?> UpdateAsync(int id, UpdateJournalDto dto);
    Task<bool> DeleteAsync(int id);
}