using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface IUserService
{
    UserResponse Add(UserCreate userCreate);
    IEnumerable<UserResponse> GetAll();
    UserResponse? Update(Guid id, UserCreate userCreate);
    UserResponse? Delete(Guid id);

    UserResponse? GetById(Guid id);
}