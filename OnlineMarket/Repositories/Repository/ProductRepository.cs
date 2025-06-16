using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Infrastructure.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class ProductRepository(AppDbContext context, ILogger<Product> logger) : IProductRepository
{
    public Product Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        return context.Products.Include(x => x.Category).ToList();
    }

    public Product? Update(Product productCreate)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == productCreate.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {product}", firstOrDefault);

            return null;
        }

        context.Products.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Product? Delete(Guid id)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {product}", firstOrDefault);

            return null;
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Product? GetById(Guid id)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {product}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}