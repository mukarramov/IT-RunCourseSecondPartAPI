using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class UserRepository : IRepository<User>
{
    public static readonly List<User> Users = [];

    public User Create(User user)
    {
        Users.Add(user);

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return Users;
    }

    public User Update(Guid id, User user)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == user.Id);

        if (findUser == null)
        {
            throw new Exception($"user by id: {user.Id} does not exist!");
        }

        findUser.Address = user.Address;
        findUser.Email = user.Email;
        findUser.FullName = user.FullName;
        findUser.Password = user.Password;
        findUser.Roule = user.Roule;
        findUser.RegisteredAt = user.RegisteredAt;

        return findUser;
    }

    public User Delete(Guid userId)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == userId);

        if (findUser == null)
        {
            throw new Exception($"user by id: {userId} does not exist");
        }

        Users.Remove(findUser);

        return findUser;
    }
}