using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public Category Add(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();

        return category;
    }

    public IQueryable<Category> GetAll()
    {
        return context.Categories;
    }

    public Category Update(Guid id, Category category)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Categories.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Category Delete(Guid id)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Category GetById(Guid id)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }
}