using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IUserRepository
{
    User Add(User user);
    IEnumerable<User> GetAll();
    User? Update(User user);
    User? Delete(Guid id);

    User? GetById(Guid id);
}