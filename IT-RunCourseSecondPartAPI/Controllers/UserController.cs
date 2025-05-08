using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult AddUser(User user, [FromServices] IUserRepository userRepository)
    {
        userRepository.Create(user);

        var userResponse = user.Adapt<UserDto>();

        return Ok(userResponse);
    }

    [HttpGet]
    public IActionResult GetAllUser([FromServices] IUserRepository userRepository)
    {
        userRepository.GetAll();

        var userResponse = UserRepository.Users.Adapt<List<UserDto>>();

        return Ok(userResponse);
    }

    [HttpPut("[action]")]
    public IActionResult UpdateUser(User user, [FromServices] IUserRepository userRepository)
    {
        userRepository.Update(user);

        var userResponse = user.Adapt<UserDto>();

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int userId, [FromServices] IUserRepository userRepository)
    {
        userRepository.Delete(userId);
        
        return Ok(true);
    }
}