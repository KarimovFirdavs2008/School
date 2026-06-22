using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class CleanerService : ICleanerService
{
    private readonly ICleanerRepository _repository;
    
    public CleanerService(ICleanerRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Cleaner>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Cleaner?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public async Task<Cleaner> CreateAsync(CreateCleanerDto dto)
    {
        var cleaner = new Cleaner
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Phone = dto.Phone,
            Age = dto.Age,
            Gender = dto.Gender,
            Experience = dto.Experience,
            Address = dto.Address,
            City = dto.City,
        };
        return await _repository.CreateAsync(cleaner);
    }

    public async Task<Cleaner?> UpdateAsync(int id,  CreateCleanerDto dto)
    {
        var cleaner = await _repository.GetByIdAsync(id);
        if (cleaner == null) return null;
        cleaner.Name = dto.Name;
        cleaner.Surname = dto.Surname;
        cleaner.Phone = dto.Phone;
        cleaner.Age = dto.Age;
        cleaner.Gender = dto.Gender;
        cleaner.Experience = dto.Experience;
        cleaner.Address = dto.Address;
        cleaner.City = dto.City;
        return await _repository.UpdateAsync(id, cleaner);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}