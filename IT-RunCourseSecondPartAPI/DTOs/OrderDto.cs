using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs;

public record OrderDto
{
    public User User { get; set; } = new();
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}