using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IProductRepository
{
    Product Add(Product product);
    IEnumerable<Product> GetAll();
    Product Update(Product product);
    Product Delete(Guid id);
    Product GetById(Guid id);

    public Category GetCategoryById(Guid id);
}