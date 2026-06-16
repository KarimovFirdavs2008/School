using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
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
        var teacher = new Teacher
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Age = dto.Age,
            Phone = dto.Phone,
            Address =  dto.Address,
            Lesson =  dto.Lesson,
            Experience =  dto.Experience,
            Salary =   dto.Salary
        };
        
        return await _repository.CreateAsync(teacher);
    }

    public async Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto dto)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null)
            return null;
        teacher.Name = dto.Name;
        teacher.Surname = dto.Surname;
        teacher.Age = dto.Age;
        teacher.Phone = dto.Phone;
        teacher.Address = dto.Address;
        teacher.Lesson = dto.Lesson;
        teacher.Experience = dto.Experience;
        teacher.Salary = dto.Salary;
        return await _repository.UpdateAsync(id, teacher);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}