using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Repository;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public static readonly List<TEntity> Entities = [];

    public TEntity Create(TEntity entity)
    {
        Entities.Add(entity);

        return entity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Entities;
    }

    public TEntity Update(Guid modelId, TEntity entity)
    {
        var findEntity = Entities.SingleOrDefault(x => x.Id == modelId);

        if (findEntity == null)
        {
            throw new($"user by id: {findEntity} does not exist!");
        }

        findEntity.Id = modelId;
        findEntity = entity;

        return findEntity;
    }

    public TEntity Delete(Guid entity)
    {
        var findEntity = Entities.SingleOrDefault(x => x.Id == entity);

        if (findEntity == null)
        {
            throw new($"user by id: {findEntity} does not exist!");
        }

        Entities.Remove(findEntity);

        return findEntity;
    }
}