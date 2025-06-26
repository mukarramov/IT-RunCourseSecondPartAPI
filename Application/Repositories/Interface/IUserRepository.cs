using Domain.Models;

namespace Application.Repositories.Interface;

public interface IUserRepository
{
    User Add(User user);
    IEnumerable<User> GetAll();
    IEnumerable<User> GetUserByPagination(int page, int pageSize);
    User? Update(User user);
    User? Delete(Guid id);

    User? GetById(Guid id);
}