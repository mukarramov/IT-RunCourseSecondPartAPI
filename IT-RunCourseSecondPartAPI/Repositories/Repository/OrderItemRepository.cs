using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderItemRepository : IOrderItemRepository
{
    public static readonly List<OrderItem> OrderItems = [];

    public OrderItem Create(OrderItem orderItem)
    {
        var product = ProductRepository.Products;
        var order = OrderRepository.Orders;

        var lookForProduct = product.SingleOrDefault(x => x.Id == orderItem.ProductId);
        if (lookForProduct == null)
        {
            throw new($"the product with id: {orderItem.ProductId} does not exist!");
        }

        var lookForOrder = order.SingleOrDefault(x => x.Id == orderItem.OrderId);
        if (lookForOrder == null)
        {
            throw new($"the order with id: {orderItem.Id} does not exist!");
        }

        orderItem.ProductId = lookForProduct.Id;
        orderItem.Product = lookForProduct;
        orderItem.OrderId = lookForOrder.Id;
        orderItem.Order = lookForOrder;

        OrderItems.Add(orderItem);

        return orderItem;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return OrderItems;
    }

    public OrderItem Update(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid orderItemId)
    {
        throw new NotImplementedException();
    }
}