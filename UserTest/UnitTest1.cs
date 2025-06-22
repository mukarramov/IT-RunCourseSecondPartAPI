using System.Net;
using System.Net.Http.Json;
using Domain.Models;
using FluentAssertions;

namespace UserTest;

public class ControllerTest(ApiFactory apiFactory, ApiFactory webApplicationFactory)
    : IClassFixture<ApiFactory>
{
    [Fact]
    public async Task CallingUserController()
    {
        // arrange
        var httpClient = webApplicationFactory.CreateClient();
        var user = new User
        {
            FullName = "ali",
            Password = "testali",
            Email = "ali@test.com",
            Address = "33-32-34"
        };

        // act
        var response = await httpClient.PostAsJsonAsync("User/Add", user);
        await response.Content.ReadFromJsonAsync<User>();

        // assert
        response.Should().NotBeNull();
        response.EnsureSuccessStatusCode();
    }
}