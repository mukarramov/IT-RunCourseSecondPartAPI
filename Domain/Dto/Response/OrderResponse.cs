using Domain.Models;

namespace Application.Dtos.Response;

public class OrderResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}