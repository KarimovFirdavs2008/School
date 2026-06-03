namespace WebApplication1.Models;

public class Journal
{
    public int Id { get; set; }
    public string TeacherName { get; set; } = "";
    public string StudentName { get; set; } = "";
    public string LessonName { get; set; } = "";
    public string Points { get; set; } = "";
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int ClassId { get; set; }
    public Class? Class { get; set; }
}