namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IService<TEntity>
{
    TEntity Add(TEntity entity);
    IEnumerable<TEntity> GetAll();
    bool Update(Guid id, TEntity entity);
    bool Delete(Guid id);

    TEntity GetById(Guid id);
}