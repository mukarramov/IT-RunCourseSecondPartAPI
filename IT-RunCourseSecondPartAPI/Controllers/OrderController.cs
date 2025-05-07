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
        var existOrNot = listOfUsers.SingleOrDefault(x => x.Id == order.UserId);

        if (existOrNot == null)
        {
            return BadRequest($"the user with id: {existOrNot} does not exist!");
        }

        order.UserId = existOrNot.Id;
        order.User = existOrNot;
        order.OrderDate = DateTime.Now;

        Orders.Add(order);

        var orderResponse = order.Adapt<OrderResponse>();

        return Ok(orderResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderResponse = Orders.Adapt<List<OrderResponse>>();

        return Ok(orderResponse);
    }
}