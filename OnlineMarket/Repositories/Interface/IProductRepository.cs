using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IProductRepository : IRepository<Product>
{
    public Category GetCategoryById(Guid id);
    public IEnumerable<Product> GetProducts();
}