using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface IProductService
{
    ProductResponse? Add(ProductCreate productCreate);
    IEnumerable<ProductResponse> GetAll();
    IEnumerable<ProductResponse> GetProductByPagination(int page, int pageSize);
    ProductResponse? Update(Guid id, ProductCreate productCreate);
    ProductResponse? Delete(Guid id);

    ProductResponse? GetById(Guid id);
}