using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class CreateJournalDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string TeacherName { get; set; } = string.Empty;
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string StudentName { get; set; } = string.Empty;
    [Required]
    public string LessonName { get; set; } = string.Empty;
    [Range(1, 10)]
    public string Points { get; set; } = string.Empty;
    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;
    [Required]
    [Range(1, 4)]
    public int ClassId { get; set; }
}