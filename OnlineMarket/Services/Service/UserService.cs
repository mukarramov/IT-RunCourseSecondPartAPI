using FluentValidation;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class UserService(IUserRepository userRepository, IValidator<UserCreate> validator)
    : IUserService
{
    public UserResponse Add(UserCreate userCreate)
    {
        if (string.IsNullOrEmpty(userCreate.Email))
        {
            throw new Exception();
        }

        var user = new User
        {
            FullName = userCreate.FullName,
            Password = userCreate.Password,
            Email = userCreate.Email,
            Address = userCreate.Address,
        };

        var result = validator.Validate(userCreate);
        if (!result.IsValid)
        {
            var errorValidate = result.Errors.Select(x => new
            {
                x.PropertyName,
                x.ErrorCode,
                x.ErrorMessage
            });
            throw new Exception($"{errorValidate}");
        }

        userRepository.Add(user);

        var userResponse = new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address
        };

        return userResponse;
    }

    public IEnumerable<UserResponse> GetAll()
    {
        var users = userRepository.GetAll();

        var userResponses = users.Select(user => new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address
        });

        return userResponses;
    }

    public UserResponse Update(Guid id, UserCreate entity)
    {
        var user = userRepository.GetById(id);

        userRepository.Update(id, user);

        var userResponse = new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address
        };

        return userResponse;
    }

    public UserResponse Delete(Guid id)
    {
        var user = userRepository.Delete(id);

        var userResponse = new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address
        };

        return userResponse;
    }

    public UserResponse GetById(Guid id)
    {
        var user = userRepository.GetById(id);

        var userResponse = new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address
        };

        return userResponse;
    }
}