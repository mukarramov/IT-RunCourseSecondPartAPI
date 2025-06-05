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
        return Ok(productService.Update(id, product));
    }

    [HttpDelete]
    public IActionResult Delete(Guid productId)
    {
        return Ok(productService.Delete(productId));
    }
}