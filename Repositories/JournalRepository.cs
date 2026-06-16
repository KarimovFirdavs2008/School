using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class JournalRepository : IJournalRepository
{
    private readonly AppDbContext _db;
    public JournalRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Journal>> GetAllAsync()
    {
        return await _db.Journals
            .Include(x => x.Class)
            .ToListAsync();
    }

    public async Task<Journal?> GetByIdAsync(int id)
    {
        return await _db.Journals
            .Include(x => x.Class)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Journal> CreateAsync(Journal journal)
    {
        _db.Journals.Add(journal);
        await _db.SaveChangesAsync();
        return journal;
    }

    public async Task<Journal?> UpdateAsync(int id, Journal journal)
    {
        await _db.SaveChangesAsync();
        return journal;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var journal = await _db.Journals.FindAsync(id);
        if (journal == null)
            return false;
        _db.Journals.Remove(journal);
        await _db.SaveChangesAsync();
        return true;
    }
}