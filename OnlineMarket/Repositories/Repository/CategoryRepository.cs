using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
{
}