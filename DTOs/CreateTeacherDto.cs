namespace WebApplication1.DTOs;

public class CreateTeacherDto
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public int Age { get; set; } 
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";
    public string Lesson { get; set; } = "";
    public string Experience { get; set; } = "";
    public decimal Salary { get; set; }
}