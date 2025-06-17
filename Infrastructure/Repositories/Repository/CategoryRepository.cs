using Application.Repositories.Interface;
using Domain.Models;
using Infrastructure.ApplicationDbContext;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Repository;

public class CategoryRepository(AppDbContext context, ILogger<Category> logger) : ICategoryRepository
{
    public Category Add(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();

        return category;
    }

    public IEnumerable<Category> GetAll()
    {
        return context.Categories.ToList();
    }

    public Category? Update(Category category)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == category.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {category}", firstOrDefault);

            return null;
        }

        context.Categories.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Category? Delete(Guid id)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {category}", firstOrDefault);

            return null;
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Category? GetById(Guid id)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {category}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}