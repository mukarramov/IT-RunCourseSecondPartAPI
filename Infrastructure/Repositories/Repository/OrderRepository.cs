using Application.Repositories.Interface;
using Domain.Models;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Repository;

public class OrderRepository(AppDbContext context, ILogger<Order> logger) : IOrderRepository
{
    public Order Add(Order orderItem)
    {
        context.Orders.Add(orderItem);
        context.SaveChanges();

        return orderItem;
    }

    public IEnumerable<Order> GetAll()
    {
        var orders = context.Orders
            .Include(x => x.User).ToList();

        return orders;
    }

    public Order? Update(Order user)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == user.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {order}", firstOrDefault);

            return null;
        }

        context.Orders.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Order? Delete(Guid id)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {order}", firstOrDefault);

            return null;
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Order? GetById(Guid id)
    {
        var firstOrDefault = context.Orders.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {order}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}