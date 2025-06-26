using Domain.Models;

namespace Application.Repositories.Interface;

public interface ICategoryRepository
{
    Category Add(Category category);
    IEnumerable<Category> GetAll();
    IEnumerable<Category> GetCategoryByPagination(int page, int pageSize);
    Category? Update(Category category);
    Category? Delete(Guid id);

    Category? GetById(Guid id);
}