using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    public static readonly List<Order> Orders = [];

    [HttpPost]
    public IActionResult Create(Order order)
    {
        var listOfUsers = UserController.Users;
        var existUser = listOfUsers.SingleOrDefault(x => x.Id == order.UserId);

        if (existUser == null)
        {
            return BadRequest($"the user with id: {existUser} does not exist!");
        }

        order.UserId = existUser.Id;
        order.User = existUser;
        order.OrderDate = DateTime.Now;

        Orders.Add(order);

        var orderResponse = order.Adapt<OrderDto>();

        return Ok(orderResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderResponse = Orders.Adapt<List<OrderDto>>();

        return Ok(orderResponse);
    }
}