namespace IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;

public class OrderCreate
{
    public Guid UserId { get; set; }
    public decimal TotalPrice { get; set; }
}