namespace IT_RunCourseSecondPartAPI.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = new Models.User();
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}