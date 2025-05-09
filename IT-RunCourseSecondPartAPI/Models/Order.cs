namespace IT_RunCourseSecondPartAPI.Models;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = new();
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}