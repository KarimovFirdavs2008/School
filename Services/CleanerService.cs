using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class CleanerService : ICleanerService
{
    private readonly ICleanerRepository _repository;
    private readonly  IMapper _mapper;
    
    public CleanerService(ICleanerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
        var cleaner = _mapper.Map<Cleaner>(dto);
        return await _repository.CreateAsync(cleaner);
    }

    public async Task<Cleaner?> UpdateAsync(int id,  CreateCleanerDto dto)
    {
        var cleaner = await _repository.GetByIdAsync(id);
        if (cleaner == null) return null;
        _mapper.Map(dto, cleaner);
        return await _repository.UpdateAsync(id, cleaner);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}