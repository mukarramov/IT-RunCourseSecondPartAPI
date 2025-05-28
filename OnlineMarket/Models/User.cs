using IT_RunCourseSecondPartAPI.Models.Enums;

namespace IT_RunCourseSecondPartAPI.Models;

public class User : IEntity
{
    public Guid Id { get; set; }=Guid.CreateVersion7();
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Roule Roule { get; set; } = Roule.Client;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
}