using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class CreateTeacherDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Name { get; set; } = "";
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Surname { get; set; } = "";
    [Required]
    [Range(16, 19)]
    public int Age { get; set; }
    [Required]
    public string Phone { get; set; } = "";
    [Required]
    public string Address { get; set; } = "";
    [Required]
    public string Lesson { get; set; } = "";
    [Required]
    public string Experience { get; set; } = "";
    [Required]
    [MinLength(1000)]
    public decimal Salary { get; set; }
}