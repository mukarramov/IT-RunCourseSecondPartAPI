using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IProductService
{
    ProductResponse Add(ProductCreate productCreate);
    IQueryable<ProductResponse> GetAll();
    ProductResponse Update(Guid id, ProductCreate productCreate);
    ProductResponse Delete(Guid id);

    ProductResponse GetById(Guid id);
}