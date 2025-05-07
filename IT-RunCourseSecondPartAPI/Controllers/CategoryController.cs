using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    public static readonly List<Category> Categories = [];

    [HttpPost]
    public IActionResult Create(Category category)
    {
        Categories.Add(category);

        var categoryResponse = category.Adapt<CategoryDto>();

        return Ok(categoryResponse);
    }
}