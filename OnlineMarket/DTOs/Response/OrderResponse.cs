using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs.Response;

public class OrderResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}