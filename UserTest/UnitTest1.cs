using System.Net;
using FluentAssertions;
using IT_RunCourseSecondPartAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace UserTest;

public class ControllerTest
{
    [Fact]
    public async Task CallingUserController()
    {
        // arrange
        var webApplicationFactory = new WebApplicationFactory<UserController>();
        var httpClient = webApplicationFactory.CreateClient();

        // act
        var response = await httpClient.GetAsync("User/GetAllUser");

        // assert
        response.Should().NotBeNull();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}