using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    [JsonIgnore]
    public List<Student> Students { get; set; } = new();
}