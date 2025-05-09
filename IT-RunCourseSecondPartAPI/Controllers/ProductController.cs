using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(Product product, [FromServices] IProductRepository productRepository)
    {
        productRepository.Create(product);

        var productResponse = productRepository.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpGet]
    public IActionResult GetAll([FromServices] IProductRepository productRepository)
    {
        productRepository.GetAll();

        var productResponse = ProductRepository.Products.Adapt<List<Product>>();

        return Ok(productResponse);
    }

    [HttpPut]
    public IActionResult Update(Product product, [FromServices] IProductRepository productRepository)
    {
        productRepository.Update(product);

        var productResponse = productRepository.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid productId, [FromServices] IProductRepository productRepository)
    {
        productRepository.Delete(productId);

        return Ok(true);
    }
}