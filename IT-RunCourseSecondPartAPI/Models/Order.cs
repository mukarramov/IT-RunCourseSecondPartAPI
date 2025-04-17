namespace IT_RunCourseSecondPartAPI.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = new Models.User();
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}