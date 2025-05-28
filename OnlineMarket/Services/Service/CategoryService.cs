using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CategoryService(IRepository<Category> categoryRepository, IMapper mapper) : ICategoryService
{
    public CategoryResponse Add(CategoryRequest entity)
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

        return mapper.Map<CategoryResponse>(category);
    }

    public IEnumerable<CategoryResponse> GetAll()
    {
        var categories = categoryRepository.GetAll();

        return mapper.Map<IEnumerable<CategoryResponse>>(categories);
    }

    public CategoryResponse Update(Guid id, CategoryRequest entity)
    {
        var category = categoryRepository.GetById(id);

        var map = mapper.Map(entity, category);

        categoryRepository.Update(id, map);

        return mapper.Map<CategoryResponse>(map);
    }

    public CategoryResponse Delete(Guid id)
    {
        var category = categoryRepository.Delete(id);

        return mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse GetById(Guid id)
    {
        var category = categoryRepository.GetById(id);

        return mapper.Map<CategoryResponse>(category);
    }
}