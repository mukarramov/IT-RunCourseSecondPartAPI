using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IProductRepository
{
    Product Add(Product user);
    IEnumerable<Product> GetAll();
    Product Update(Guid id, Product product);
    Product Delete(Guid id);
    Product GetById(Guid id);

    public Category GetCategoryById(Guid id);
    public IEnumerable<Product> GetProducts();
}