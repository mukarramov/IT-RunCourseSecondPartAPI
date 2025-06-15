using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class UserRepository(AppDbContext context, ILogger<User> logger) : IUserRepository
{
    public User Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return context.Users.ToList();
    }

    public User? Update(User user)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {user}", firstOrDefault);

            return null;
        }

        context.Users.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public User? Delete(Guid id)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {user}", firstOrDefault);

            return null;
        }

        context.Users.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public User? GetById(Guid id)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {user}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}