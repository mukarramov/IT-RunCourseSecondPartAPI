using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

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
            .Include(x => x.Product);
    }

    public OrderItem Update(OrderItem orderItem)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == orderItem.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            throw new Exception();
        }

        context.OrderItems.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem Delete(Guid id)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            throw new Exception();
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem GetById(Guid id)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {orderItem}", firstOrDefault);

            throw new Exception();
        }

        return firstOrDefault;
    }

    public Product GetProductById(Guid id)
    {
        var product = context.Products.Include(x => x.Category)
            .FirstOrDefault(x => x.Id == id);
        if (product is null)
        {
            logger.LogError("can not found the {product}", product);

            throw new Exception();
        }

        return product;
    }

    public Order GetOrderById(Guid id)
    {
        var order = context.Orders.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        if (order is null)
        {
            logger.LogError("can not found the {order}", order);

            throw new Exception();
        }

        return order;
    }
}