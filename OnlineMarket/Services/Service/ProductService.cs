using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ProductService(IRepository<Product> productRepository) : IService<Product>
{
    public Product Add(Product product)
    {
        productRepository.Create(product);

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        return ProductRepository.Products;
    }

    public bool Update(Guid id, Product product)
    {
        productRepository.Update(id, product);

        return true;
    }

    public bool Delete(Guid id)
    {
        productRepository.Delete(id);

        return true;
    }

    public Product GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}