using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class CreateStudentDto
{
    [Required]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Range(7, 100)]
    public int Age { get; set; }
    [Required]
    public string Phone { get; set; }= string.Empty;
    [Required]
    public string Address { get; set; }= string.Empty;
    [Required]
    public int ClassId { get; set; }
}