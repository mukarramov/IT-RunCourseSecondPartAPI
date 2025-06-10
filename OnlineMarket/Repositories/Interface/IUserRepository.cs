using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IUserRepository
{
    User Add(User user);
    IQueryable<User> GetAll();
    User Update(Guid id, User user);
    User Delete(Guid id);

    User GetById(Guid id);
}