using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IUserService
{
    UserResponse Add(UserCreate userCreate);
    IEnumerable<UserResponse> GetAll();
    UserResponse? Update(Guid id, UserCreate userCreate);
    UserResponse? Delete(Guid id);

    UserResponse? GetById(Guid id);
}