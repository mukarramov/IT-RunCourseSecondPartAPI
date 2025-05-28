using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IProductService
{
    ProductResponse Add(ProductRequest productRequest);
    IEnumerable<ProductResponse> GetAll();
    ProductResponse Update(Guid id, ProductRequest productRequest);
    ProductResponse Delete(Guid id);

    ProductResponse GetById(Guid id);
}