using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICategoryRepository
{
    Category Add(Category category);
    IEnumerable<Category> GetAll();
    Category Update(Category category);
    Category Delete(Guid id);

    Category GetById(Guid id);
}