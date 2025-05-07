using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    public static readonly List<Product> Products = [];

    [HttpPost]
    public IActionResult Create(Product product)
    {
        var categories = CategoryController.Categories;

        var lookForCategory = categories.SingleOrDefault(x => x.Id == product.CategoryId);
        if (lookForCategory == null)
        {
            return BadRequest($"the product category with id: {product.CategoryId} does not exist!");
        }

        product.CategoryId = lookForCategory.Id;
        product.Category = lookForCategory;

        Products.Add(product);

        var productResponse = product.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var productResponse = Products.Adapt<List<ProductDto>>();

        return Ok(productResponse);
    }

    [HttpPut]
    public IActionResult Update(Product product)
    {
        var lookForProduct = Products.SingleOrDefault(x => x.Id == product.Id);

        if (lookForProduct == null)
        {
            return BadRequest($"the product with id: {product.Id} does not exist!");
        }

        var productResponse = lookForProduct.Adapt<ProductDto>();

        return Ok(productResponse);
    }

    [HttpDelete]
    public IActionResult Delete(int productId)
    {
        var lookForProduct = Products.SingleOrDefault(x => x.Id == productId);

        if (lookForProduct == null)
        {
            return BadRequest($"the product with id: {productId} does not exist!");
        }

        return Ok("successfully deleted!");
    }
}