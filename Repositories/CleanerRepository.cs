using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class CleanerRepository : ICleanerRepository
{
    private readonly AppDbContext _db;
    public CleanerRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Cleaner>> GetAllAsync()
    {
        return await _db.Cleaners.ToListAsync();
    }

    public async Task<Cleaner?> GetByIdAsync(int id)
    {
        return await _db.Cleaners.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cleaner> CreateAsync(Cleaner cleaner)
    {
        _db.Cleaners.Add(cleaner);
        await _db.SaveChangesAsync();
        return cleaner;
    }

    public async Task<Cleaner?> UpdateAsync(int id, Cleaner cleaner)
    {
        await _db.SaveChangesAsync();
        return cleaner;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cleaner = await _db.Cleaners.FindAsync(id);
        if (cleaner == null) 
            return false;
        _db.Cleaners.Remove(cleaner);
        await _db.SaveChangesAsync();
        return true;
    }
}