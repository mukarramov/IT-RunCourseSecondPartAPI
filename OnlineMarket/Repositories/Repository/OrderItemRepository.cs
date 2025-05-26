using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderItemRepository : IRepository<OrderItem>
{
    public static readonly List<OrderItem> OrderItems = [];

    public OrderItem Create(OrderItem orderItem)
    {
        var product = ProductRepository.Products;
        var order = OrderRepository.Orders;

        var lookForProduct = product.SingleOrDefault(x => x.Id == orderItem.ProductId);
        if (lookForProduct == null)
        {
            throw new Exception($"the product with id: {orderItem.ProductId} does not exist!");
        }

        var lookForOrder = order.SingleOrDefault(x => x.Id == orderItem.OrderId);
        if (lookForOrder == null)
        {
            throw new Exception($"the order with id: {orderItem.Id} does not exist!");
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

    public OrderItem Update(Guid id, OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public OrderItem Delete(Guid orderItemId)
    {
        throw new NotImplementedException();
    }
}