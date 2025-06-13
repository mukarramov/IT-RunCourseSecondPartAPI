using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
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
        return categoryRepository.GetAll().ToList()
            .Select(x => mapper.Map<CategoryResponse>(x));
    }

    public CategoryResponse Update(Guid id, CategoryCreate entity)
    {
        var category = categoryRepository.GetById(id);

        category.Id = id;
        category.Name = entity.Name;

        categoryRepository.Update(category);

        return mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse Delete(Guid id)
    {
        return mapper.Map<CategoryResponse>
            (categoryRepository.Delete(id));
    }

    public CategoryResponse GetById(Guid id)
    {
        return mapper.Map<CategoryResponse>
            (categoryRepository.GetById(id));
    }
}