using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface ICategoryService
{
    CategoryResponse Add(CategoryCreate categoryCreate);
    IEnumerable<CategoryResponse> GetAll();
    CategoryResponse Update(Guid id, CategoryCreate categoryCreate);
    CategoryResponse Delete(Guid id);

    CategoryResponse GetById(Guid id);
}