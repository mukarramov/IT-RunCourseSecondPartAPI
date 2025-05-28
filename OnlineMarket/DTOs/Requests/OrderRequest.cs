namespace IT_RunCourseSecondPartAPI.DTOs.Requests;

public class OrderRequest
{
    public Guid UserId { get; set; }
    public decimal TotalPrice { get; set; }
}