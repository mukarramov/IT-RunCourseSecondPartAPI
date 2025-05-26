using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IService<Product> productService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(Product product)
    {
        productService.Add(product);

        var productResponse = product.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var productResponse = ProductRepository.Products.Adapt<List<Product>>();

        return Ok(productResponse);
    }

    [HttpPut]
    public IActionResult Update(Guid id, Product product)
    {
        productService.Update(id, product);
        var productResponse = product.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid productId)
    {
        productService.Delete(productId);

        return Ok(true);
    }
}