using IT_RunCourseSecondPartAPI.Controllers;
using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Mapster;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class OrderRepository : IOrderRepository
{
    public static readonly List<Order> Orders = [];

    public Order Create(Order order)
    {
        var listOfUsers = UserRepository.Users;
        var existUser = listOfUsers.SingleOrDefault(x => x.Id == order.UserId);

        if (existUser == null)
        {
            throw new($"the user with id: {existUser} does not exist!");
        }

        order.UserId = existUser.Id;
        order.User = existUser;
        order.OrderDate = DateTime.Now;

        Orders.Add(order);

        return order;
    }

    public IEnumerable<Order> GetAll()
    {
        return Orders;
    }

    public Order Update(Order order)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int orderId)
    {
        throw new NotImplementedException();
    }
}