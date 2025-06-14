using AutoMapper;
using FluentValidation;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class UserService(IUserRepository userRepository, IMapper mapper, IValidator<UserCreate> validator)
    : IUserService
{
    public UserResponse Add(UserCreate userCreate)
    {
        if (string.IsNullOrEmpty(userCreate.Email))
        {
            throw new Exception();
        }

        var user = mapper.Map<User>(userCreate);

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

        return mapper.Map<UserResponse>(user);
    }

    public IEnumerable<UserResponse> GetAll()
    {
        return userRepository.GetAll().ToList()
            .Select(x => mapper.Map<UserResponse>(x));
    }

    public UserResponse Update(Guid id, UserCreate userCreate)
    {
        var user = userRepository.GetById(id);

        user.Id = id;

        var map = mapper.Map(userCreate, user);

        userRepository.Update(map);

        return mapper.Map<UserResponse>(map);
    }

    public UserResponse Delete(Guid id)
    {
        return mapper.Map<UserResponse>
            (userRepository.Delete(id));
    }

    public UserResponse GetById(Guid id)
    {
        return mapper.Map<UserResponse>
            (userRepository.GetById(id));
    }
}