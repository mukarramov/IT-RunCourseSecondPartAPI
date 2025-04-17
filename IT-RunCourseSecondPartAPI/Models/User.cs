namespace IT_RunCourseSecondPartAPI.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
}