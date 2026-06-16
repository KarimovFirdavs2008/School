using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Student> CreateAsync(CreateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Age = dto.Age,
            Phone = dto.Phone,
            Address = dto.Address,
            ClassId = dto.ClassId
        };

        return await _repository.CreateAsync(student);
    }

    public async Task<Student?> UpdateAsync(int id, UpdateStudentDto dto)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
            return null;

        student.Name = dto.Name;
        student.Surname = dto.Surname;
        student.Age = dto.Age;
        student.Phone = dto.Phone;
        student.Address = dto.Address;
        student.ClassId = dto.ClassId;

        return await _repository.UpdateAsync(id, student);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}