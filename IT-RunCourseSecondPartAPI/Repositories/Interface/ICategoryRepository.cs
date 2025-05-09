using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICategoryRepository
{
    Category Create(Category category);
    IEnumerable<Category> GetAll();
    Category Update(Category category);
    bool Delete(Guid categoryId);
}