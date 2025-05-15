using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class Service(IUserRepository userRepository) : IService<User>
{
    public User Add(User user)
    {
        userRepository.Create(user);

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return UserRepository.Users;
    }

    public bool Update(Guid id, User user)
    {
        userRepository.Update(user);
        return true;
    }

    public bool Delete(Guid id)
    {
        userRepository.Delete(id);
        return true;
    }

    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}