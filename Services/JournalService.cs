using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class JournalService : IJournalService
{
    private readonly IJournalRepository _repository;
    private readonly IMapper _mapper;
    public JournalService(IJournalRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Journal>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<Journal?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Journal> CreateAsync(CreateJournalDto dto)
    {
        var journal = _mapper.Map<Journal>(dto);
        return await _repository.CreateAsync(journal);
    }

    public async Task<Journal?> UpdateAsync(int id, UpdateJournalDto dto)
    {
        var journal = await _repository.GetByIdAsync(id);
        if (journal == null)
            return null;
        _mapper.Map(dto, journal);
        return await _repository.UpdateAsync(id, journal);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}