using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IUserRepository
{
    User Create(User user);
    IEnumerable<User> GetAll();
    User Update(User user);
    bool Delete(Guid userId);
}