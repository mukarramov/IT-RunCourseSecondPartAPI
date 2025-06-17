using Domain.Models;

namespace Application.Repositories.Interface;

public interface ICategoryRepository
{
    Category Add(Category category);
    IEnumerable<Category> GetAll();
    Category? Update(Category category);
    Category? Delete(Guid id);

    Category? GetById(Guid id);
}