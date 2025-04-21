using IT_RunCourseSecondPartAPI.Models.Enums;

namespace IT_RunCourseSecondPartAPI.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Roule Roule { get; set; }
    public DateTime RegisteredAt { get; set; }
}