using Application.Repositories.Interface;
using Domain.Models;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Repository;

public class OrderItemRepository(AppDbContext context, ILogger<OrderItem> logger) : IOrderItemRepository
{
    public OrderItem Add(OrderItem orderItem)
    {
        context.OrderItems.Add(orderItem);
        context.SaveChanges();

        return orderItem;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return context.OrderItems.Include(x => x.Order)
            .Include(x => x.Product).ToList();
    }

    public OrderItem? Update(OrderItem orderItem)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == orderItem.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            return null;
        }

        context.OrderItems.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem? Delete(Guid id)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            return null;
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem? GetById(Guid id)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}