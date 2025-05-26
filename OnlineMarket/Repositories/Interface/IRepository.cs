namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IRepository<TEntity>
{
    TEntity Create(TEntity entity);
    IEnumerable<TEntity> GetAll();
    TEntity Update(Guid id, TEntity entity);
    TEntity Delete(Guid categoryId);
}