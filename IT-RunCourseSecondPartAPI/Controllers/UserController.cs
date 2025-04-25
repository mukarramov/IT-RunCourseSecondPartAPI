using IT_RunCourseSecondPartAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private static readonly List<User> Users = new List<User>();

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        Users.Add(user);
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        return Ok(Users);
    }

    [HttpPut("[action]")]
    public IActionResult UpdateUser(int id, User user)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == id);

        if (findUser == null)
        {
            return NotFound($"user by id: {id} does not exist!");
        }

        findUser.Address = user.Address;
        findUser.Email = user.Email;
        findUser.FullName = user.FullName;
        findUser.Password = user.Password;
        findUser.Roule = user.Roule;
        findUser.RegisteredAt = user.RegisteredAt;

        return Ok(findUser);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == id);

        if (findUser == null)
        {
            return NotFound($"user by id: {id} does not exist");
        }

        Users.RemoveAt(id);
        return Ok();
    }
}