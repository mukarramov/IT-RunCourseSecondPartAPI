using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IUserService
{
    UserResponse Add(UserRequest userRequest);
    IEnumerable<UserResponse> GetAll();
    UserResponse Update(Guid id, UserRequest userRequest);
    UserResponse Delete(Guid id);

    UserResponse GetById(Guid id);
}