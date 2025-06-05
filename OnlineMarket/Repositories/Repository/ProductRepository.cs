using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public Product Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        var products = context.Products.Include(x => x.Category).ToList();

        if (products.Count < 1)
        {
            throw new Exception();
        }

        return products;
    }

    public Product Update(Guid id, Product user)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Products.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Product Delete(Guid id)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        context.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public Product GetById(Guid id)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }

    public Category GetCategoryById(Guid id)
    {
        var firstOrDefault = context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }
}