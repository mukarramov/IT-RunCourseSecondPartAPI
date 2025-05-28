using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class UserService(IUserRepository userRepository, IMapper mapper, IServiceProvider service) : IUserService
{
    public UserResponse Add(UserRequest entity)
    {
        if (string.IsNullOrEmpty(entity.Email))
        {
            throw new Exception();
        }

        var user = new User
        {
            FullName = entity.FullName,
            Password = entity.Password,
            Email = entity.Email,
            Address = entity.Address,
        };

        userRepository.Add(user);
        return mapper.Map<UserResponse>(user);
    }

    public IEnumerable<UserResponse> GetAll()
    {
        var users = userRepository.GetAll();

        return mapper.Map<IEnumerable<UserResponse>>(users);
    }

    public UserResponse Update(Guid id, UserRequest entity)
    {
        var user = userRepository.GetById(id);

        var map = mapper.Map(entity, user);

        userRepository.Update(id, map);

        return mapper.Map<UserResponse>(map);
    }

    public UserResponse Delete(Guid id)
    {
        var delete = userRepository.Delete(id);

        return mapper.Map<UserResponse>(delete);
    }

    public UserResponse GetById(Guid id)
    {
        var user = userRepository.GetById(id);

        return mapper.Map<UserResponse>(user);
    }
}