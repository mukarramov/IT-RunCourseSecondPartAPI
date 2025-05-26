using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class CategoryRepository : IRepository<Category>
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

    public Category Update(Guid id, Category category)
    {
        var findUser = Categories.FirstOrDefault(x => x.Id == id);

        if (findUser == null)
        {
            throw new Exception($"user by id: {id} does not exist!");
        }

        findUser.Name = category.Name;

        return findUser;
    }

    public Category Delete(Guid categoryId)
    {
        var findUser = Categories.FirstOrDefault(x => x.Id == categoryId);

        if (findUser == null)
        {
            throw new Exception($"user by id: {categoryId} does not exist!");
        }

        Categories.Remove(findUser);

        return findUser;
    }
}