using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICategoryRepository
{
    Category Add(Category category);
    IQueryable<Category> GetAll();
    Category Update(Guid id, Category category);
    Category Delete(Guid id);

    Category GetById(Guid id);
}