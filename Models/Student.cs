namespace WebApplication1.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public int Age { get; set; }
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";
    public int ClassId { get; set; }
    public Class? Class { get; set; }
}