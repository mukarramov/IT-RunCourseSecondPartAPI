using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILogger<Category> logger)
    : ICategoryService
{
    public CategoryResponse Add(CategoryCreate categoryCreate)
    {
        if (string.IsNullOrEmpty(categoryCreate.Name))
        {
            throw new Exception();
        }

        var category = mapper.Map<Category>(categoryCreate);

        categoryRepository.Add(category);

        return mapper.Map<CategoryResponse>(category);
    }

    public IEnumerable<CategoryResponse> GetAll()
    {
        return categoryRepository.GetAll()
            .Select(mapper.Map<CategoryResponse>);
    }

    public CategoryResponse? Update(Guid id, CategoryCreate entity)
    {
        var category = categoryRepository.GetById(id);
        if (category is null)
        {
            return null;
        }

        category.Id = id;
        category.Name = entity.Name;

        categoryRepository.Update(category);

        logger.LogInformation("update {category} successfully passed", category);

        return mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse? Delete(Guid id)
    {
        var category = categoryRepository.Delete(id);

        return category is null ? null : mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse? GetById(Guid id)
    {
        var category = categoryRepository.Delete(id);

        return category is null ? null : mapper.Map<CategoryResponse>(category);
    }
}