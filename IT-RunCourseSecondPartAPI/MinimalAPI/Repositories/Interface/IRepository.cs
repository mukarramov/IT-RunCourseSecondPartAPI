using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    TEntity Create(TEntity model);
    IEnumerable<TEntity> GetAll();
    TEntity Update(Guid modelId, TEntity model);
    TEntity Delete(Guid modelId);
}