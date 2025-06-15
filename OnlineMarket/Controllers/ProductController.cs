using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(ProductCreate product)
    {
        return Ok(productService.Add(product));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(productService.GetAll());
    }

    [HttpPut]
    public IActionResult Update(Guid id, ProductCreate product)
    {
        var productResponse = productService.Update(id, product);

        if (productResponse is null)
        {
            return NotFound();
        }

        return Ok(productResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid productId)
    {
        var productResponse = productService.Delete(productId);

        if (productResponse is null)
        {
            return NotFound();
        }

        return Ok(productResponse);
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var productResponse = productService.GetById(id);

        if (productResponse is null)
        {
            return NotFound();
        }

        return Ok(productResponse);
    }
}