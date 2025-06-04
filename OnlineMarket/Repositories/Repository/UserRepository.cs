using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public User Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return context.Users.Where(x => x.IsDeleted == false);
    }

    public User Update(Guid id, User user)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted==false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Users.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public User Delete(Guid id)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted==false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        firstOrDefault.IsDeleted = true;
        context.SaveChanges();

        return firstOrDefault;
    }

    public User GetById(Guid id)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted==false);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }
}