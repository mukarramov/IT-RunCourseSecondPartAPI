using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface ICategoryService
{
    CategoryResponse Add(CategoryCreate categoryCreate);
    IEnumerable<CategoryResponse> GetAll();
    CategoryResponse? Update(Guid id, CategoryCreate categoryCreate);
    CategoryResponse? Delete(Guid id);

    CategoryResponse? GetById(Guid id);
}