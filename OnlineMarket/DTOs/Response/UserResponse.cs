namespace IT_RunCourseSecondPartAPI.DTOs.Response;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}