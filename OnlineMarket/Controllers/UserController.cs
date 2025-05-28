using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(UserRequest userRequest)
    {
        return Ok(userService.Add(userRequest));
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        return Ok(userService.GetAll());
    }

    [HttpPut("[action]")]
    public IActionResult UpdateUser(Guid id, UserRequest userRequest)
    {
        var userResponse = userService.Update(id, userRequest);

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(Guid userId)
    {
        var userResponse = userService.Delete(userId);

        return Ok(userResponse);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var userResponse = userService.GetById(id);

        return Ok(userResponse);
    }
}