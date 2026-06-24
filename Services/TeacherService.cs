using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IMapper _mapper;
    public TeacherService(ITeacherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<Teacher>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Teacher?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public async Task<Teacher> CreateAsync(CreateTeacherDto dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);
        
        return await _repository.CreateAsync(teacher);
    }

    public async Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto dto)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null)
            return null;
        _mapper.Map(dto, teacher);
        return await _repository.UpdateAsync(id, teacher);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}