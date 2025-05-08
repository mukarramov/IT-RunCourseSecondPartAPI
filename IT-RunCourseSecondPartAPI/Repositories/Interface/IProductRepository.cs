using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IProductRepository
{
    Product Create(Product product);
    IEnumerable<Product> GetAll();
    Product Update(Product product);
    bool Delete(int productId);
}