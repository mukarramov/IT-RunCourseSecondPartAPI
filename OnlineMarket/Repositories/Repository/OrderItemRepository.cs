using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderItemRepository(AppDbContext context) : IOrderItemRepository
{
    public OrderItem Add(OrderItem orderItem)
    {
        context.OrderItems.Add(orderItem);
        context.SaveChanges();

        return orderItem;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        var includableQueryable = context.OrderItems
            .Include(x => x.Order)
            .Where(x => x.IsDeleted == false)
            .Include(x => x.Product)
            .Where(x => x.IsDeleted == false);

        if (includableQueryable is null)
        {
            throw new Exception();
        }

        return includableQueryable;
    }

    public OrderItem Update(Guid id, OrderItem orderItem)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.OrderItems.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem Delete(Guid id)
    {
        var firstOrDefault = context.OrderItems.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        firstOrDefault.IsDeleted = true;
        context.SaveChanges();

        return firstOrDefault;
    }

    public OrderItem GetById(Guid id)
    {
        var firstOrDefault = context.OrderItems
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }

    public Product GetProductById(Guid id)
    {
        var product = context.Products.Include(x => x.Category)
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if (product is null)
        {
            throw new Exception();
        }

        return product;
    }

    public Order GetOrderById(Guid id)
    {
        var order = context.Orders.Include(x => x.User)
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if (order is null)
        {
            throw new Exception();
        }

        return order;
    }
}