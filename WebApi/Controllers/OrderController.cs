using Application.Dtos.CreatedRequest;
using Application.Services.Interface;
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
    
    [HttpGet]
    public IActionResult GetOrderByPagination(int page, int pageSize)
    {
        return Ok(orderService.GetOrderByPagination(page, pageSize));
    }

    [HttpPut]
    public IActionResult Update(Guid id, OrderCreate orderCreate)
    {
        var orderResponse = orderService.Update(id, orderCreate);

        if (orderResponse is null)
        {
            return NotFound();
        }

        return Ok(orderResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var orderResponse = orderService.Delete(id);

        if (orderResponse is null)
        {
            return NotFound();
        }

        return Ok(orderResponse);
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var orderResponse = orderService.GetById(id);

        if (orderResponse is null)
        {
            return NotFound();
        }

        return Ok(orderResponse);
    }
}