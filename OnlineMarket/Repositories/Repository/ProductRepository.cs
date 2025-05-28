using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
{
    private readonly AppDbContext _context = context;

    public Category GetCategoryById(Guid id)
    {
        var firstOrDefault = _context.Categories.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            throw new Exception();
        }

        return firstOrDefault;
    }

    public IEnumerable<Product> GetProducts()
    {
        var products = _context.Products.Include(x => x.Category).ToList();
        if (products is null)
        {
            throw new Exception();
        }

        return products;
    }
}