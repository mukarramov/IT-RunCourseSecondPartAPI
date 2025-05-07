namespace IT_RunCourseSecondPartAPI.DTOs;

/// <summary>
/// The DTO is the simple response for showing to user (for return)
/// For example you have the id, header and something like that you do not want to show that data to user,
/// and maybe you want to user can not change that data
/// </summary>
public record UserResponse
{
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}