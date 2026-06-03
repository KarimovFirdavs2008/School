namespace WebApplication1.DTOs;

public class CreateJournalDto
{
    public string TeacherName { get; set; } = "";
    public string StudentName { get; set; } = "";
    public string LessonName { get; set; } = "";
    public string Points { get; set; } = "";
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int ClassId { get; set; }
}