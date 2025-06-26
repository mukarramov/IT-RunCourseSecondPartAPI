using Domain.Models;

namespace Application.Repositories.Interface;

public interface IProductRepository
{
    Product Add(Product product);
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetProductByPagination(int page, int pageSize);
    Product? Update(Product product);
    Product? Delete(Guid id);

    Product? GetById(Guid id);
}