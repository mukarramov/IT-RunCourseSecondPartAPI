namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IGenericRepository<T> where T : class
{
    T Create(T model);
    List<T> GetAll();
    T Update(T model);
    T Delete(T model);
}