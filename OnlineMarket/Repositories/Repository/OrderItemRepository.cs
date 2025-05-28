using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderItemRepository(AppDbContext context) : Repository<OrderItem>(context), IOrderItemRepository
{
    private readonly AppDbContext _context = context;

    public Product GetProductById(Guid id)
    {
        var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        if (product is null)
        {
            throw new Exception();
        }

        return product;
    }

    public Order GetOrderById(Guid id)
    {
        var order = _context.Orders.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        if (order is null)
        {
            throw new Exception();
        }

        return order;
    }

    public IEnumerable<OrderItem> GetOrderItems()
    {
        var includableQueryable = _context.OrderItems.Include(x => x.Order)
            .Include(x => x.Product);
        if (includableQueryable is null)
        {
            throw new Exception();
        }

        return includableQueryable;
    }
}