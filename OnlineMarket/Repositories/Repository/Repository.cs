using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : class, IEntity
{
    public TEntity Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        context.SaveChanges();

        return entity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }

    public TEntity Update(Guid id, TEntity entity)
    {
        var firstOrDefault = context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new NullReferenceException();
        }

        context.Set<TEntity>().Update(entity);
        context.SaveChanges();

        return entity;
    }

    public TEntity Delete(Guid id)
    {
        var firstOrDefault = context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new NullReferenceException();
        }

        context.Set<TEntity>().Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public TEntity GetById(Guid id)
    {
        var firstOrDefault = context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }
}