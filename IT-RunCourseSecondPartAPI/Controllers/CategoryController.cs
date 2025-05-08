using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(Category category, [FromServices] ICategoryRepository categoryRepository)
    {
        categoryRepository.Create(category);

        var categoryResponse = category.Adapt<CategoryDto>();

        return Ok(categoryResponse);
    }

    [HttpGet]
    public IActionResult GetAll([FromServices] ICategoryRepository categoryRepository)
    {
        categoryRepository.GetAll();

        var categoryResponse = CategoryRepository.Categories.Adapt<List<CategoryDto>>();

        return Ok(categoryResponse);
    }
}