using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class GenericRepository : IGenericRepository<User>
{
    public User Create(User model)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        return UserRepository.Users;
    }

    public User Update(User model)
    {
        throw new NotImplementedException();
    }

    public User Delete(User model)
    {
        throw new NotImplementedException();
    }
}