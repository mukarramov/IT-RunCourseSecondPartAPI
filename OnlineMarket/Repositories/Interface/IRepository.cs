using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    TEntity Add(TEntity entity);
    IEnumerable<TEntity> GetAll();
    TEntity Update(Guid id, TEntity entity);
    TEntity Delete(Guid id);

    TEntity GetById(Guid id);
}