using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(OrderCreate orderCreate)
    {
        return Ok(orderService.Add(orderCreate));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(orderService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(orderService.GetById(id));
    }

    [HttpPut]
    public IActionResult Update(Guid id, OrderCreate orderCreate)
    {
        return Ok(orderService.Update(id, orderCreate));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(orderService.Delete(id));
    }
}