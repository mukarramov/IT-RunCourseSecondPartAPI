using AutoMapper;
using FluentValidation;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Exceptions;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Endpoints;

/// <summary>
/// This is a minimal api and also the extended method
/// </summary>
public static class Users
{
    public static void MapUserApis(this WebApplication app)
    {
        app.MapPost("api/create/user",
            (User user, [FromServices] IUserRepository userRepository,
                [FromServices] IMapper mapper) =>
            {
                userRepository.Add(user);

                var createdUser = mapper.Map<UserResponse>(user);

                return Results.Ok(createdUser);
            });

        // use validators in post method (FluentValidation)
        app.MapPost("api/addUser/validation", (User user, [FromServices] IValidator<User> validator,
            [FromServices] IUserRepository userRepository) =>
        {
            if (user is null)
            {
                return Results.BadRequest("Client is null");
            }

            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new
                {
                    e.PropertyName, e.ErrorMessage
                });

                return Results.BadRequest(new { Errors = errors });
            }

            userRepository.Add(user);

            return Results.Ok(user);
        });

        // use exceptions in post method (try catch)
        app.MapPost("api/addUser/useExceptions", (User user,
            [FromServices] IUserRepository userRepository) =>
        {
            try
            {
                if (string.IsNullOrEmpty(user.FullName))
                {
                    throw new BadRequestException("fulName is required!");
                }
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

            userRepository.Add(user);

            return Results.Ok(user);
        });

        app.MapGet("api/getAll/user",
            ([FromServices] IUserRepository repository) =>
            {
                var usersResponse = repository.GetAll();

                return Results.Ok(usersResponse);
            });
    }
}