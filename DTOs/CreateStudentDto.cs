namespace WebApplication1.DTOs;

public class CreateStudentDto
{
    
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Phone { get; set; }= string.Empty;
    public string Address { get; set; }= string.Empty;
    public int ClassId { get; set; }
}