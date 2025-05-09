using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class CategoryRepository : ICategoryRepository
{
    public static readonly List<Category> Categories = [];

    public Category Create(Category category)
    {
        Categories.Add(category);

        return category;
    }

    public IEnumerable<Category> GetAll()
    {
        return Categories;
    }

    public Category Update(Category category)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid categoryId)
    {
        throw new NotImplementedException();
    }
}