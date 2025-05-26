using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CategoryService(IRepository<Category> categoryRepository) : IService<Category>
{
    public Category Add(Category category)
    {
        categoryRepository.Create(category);

        return category;
    }

    public IEnumerable<Category> GetAll()
    {
        return CategoryRepository.Categories;
    }

    public bool Update(Guid id, Category entity)
    {
        categoryRepository.Update(id, entity);

        return true;
    }

    public bool Delete(Guid id)
    {
        categoryRepository.Delete(id);

        return true;
    }

    public Category GetById(Guid id)
    {
        return categoryRepository.Delete(id);
    }
}