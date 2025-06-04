using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public CategoryResponse Add(CategoryCreate entity)
    {
        if (string.IsNullOrEmpty(entity.Name))
        {
            throw new Exception();
        }

        var category = new Category
        {
            Name = entity.Name
        };

        categoryRepository.Add(category);

        var categoryResponse = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        };

        return categoryResponse;
    }

    public IEnumerable<CategoryResponse> GetAll()
    {
        var categories = categoryRepository.GetAll();

        var categoryResponses = categories.Select(category => new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        });

        return categoryResponses;
    }

    public CategoryResponse Update(Guid id, CategoryCreate entity)
    {
        var category = categoryRepository.GetById(id);

        category.Name = entity.Name;

        categoryRepository.Update(id, category);

        var categoryResponse = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        };

        return categoryResponse;
    }

    public CategoryResponse Delete(Guid id)
    {
        var category = categoryRepository.Delete(id);

        var categoryResponse = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        };

        return categoryResponse;
    }

    public CategoryResponse GetById(Guid id)
    {
        var category = categoryRepository.GetById(id);

        var categoryResponse = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        };

        return categoryResponse;
    }
}