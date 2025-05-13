using AutoMapper;
using FluentValidation;
using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Exceptions;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Extensions;

/// <summary>
/// This is a minimal api and also the extended method
/// </summary>
public static class UserApiExtension
{
    public static void MapUserApis(this WebApplication app)
    {
        app.MapPost("api/create/user",
            (User user, [FromServices] IRepository<User> repository, [FromServices] IMapper mapper) =>
            {
                repository.Create(user);

                var createdUser = mapper.Map<UserDto>(user);

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

            userRepository.Create(user);

            return Results.Ok(user);
        });

        // use exceptions in post method (try catch)
        app.MapPost("api/addUser/useExceptions", (User user, [FromServices] IValidator<User> validator,
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

            userRepository.Create(user);

            return Results.Ok(user);
        });

        app.MapGet("api/getAll/user",
            ([FromServices] IRepository<User> repository) =>
            {
                var usersResponse = Repository<User>.Entities.Adapt<List<UserDto>>();

                return Results.Ok(usersResponse);
            });
    }
}