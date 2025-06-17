using Application.Dtos.CreatedRequest;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CartItemController(ICartItemService cartItemService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(CartItemCreate cartItemCreate)
    {
        return Ok(cartItemService.Add(cartItemCreate));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(cartItemService.GetAll());
    }

    [HttpPut]
    public IActionResult Update(Guid id, CartItemCreate cartItemCreate)
    {
        var cartItemResponse = cartItemService.Update(id, cartItemCreate);

        if (cartItemResponse is null)
        {
            return NotFound();
        }

        return Ok(cartItemResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var cartItemResponse = cartItemService.Delete(id);

        if (cartItemResponse is null)
        {
            return NotFound();
        }

        return Ok(cartItemResponse);
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var cartItemResponse = cartItemService.GetById(id);

        if (cartItemResponse is null)
        {
            return NotFound();
        }

        return Ok(cartItemResponse);
    }
}