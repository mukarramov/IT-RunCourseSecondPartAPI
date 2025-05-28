using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderRepository(AppDbContext context) : Repository<Order>(context), IOrderRepository
{
    private readonly AppDbContext _context = context;

    public User GetUserById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            throw new Exception();
        }

        return user;
    }

    public IEnumerable<Order> GetOrders()
    {
        var orders = _context.Orders.Include(x => x.User).ToList();
        if (orders is null)
        {
            throw new Exception();
        }

        return orders;
    }
}