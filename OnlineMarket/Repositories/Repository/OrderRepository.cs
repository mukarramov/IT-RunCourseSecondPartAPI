using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public Order Add(Order orderItem)
    {
        context.Orders.Add(orderItem);
        context.SaveChanges();

        return orderItem;
    }

    public IEnumerable<Order> GetAll()
    {
        var orders = context.Orders.Include(x => x.User).ToList();

        return orders;
    }

    public Order Update(Guid id, Order user)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Orders.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Order Delete(Guid id)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Order GetById(Guid id)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }

    public User GetUserById(Guid id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            throw new Exception();
        }

        return user;
    }
}