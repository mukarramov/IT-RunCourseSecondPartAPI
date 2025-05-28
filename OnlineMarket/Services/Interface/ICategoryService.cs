using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface ICategoryService
{
    CategoryResponse Add(CategoryRequest categoryRequest);
    IEnumerable<CategoryResponse> GetAll();
    CategoryResponse Update(Guid id, CategoryRequest categoryRequest);
    CategoryResponse Delete(Guid id);

    CategoryResponse GetById(Guid id);
}