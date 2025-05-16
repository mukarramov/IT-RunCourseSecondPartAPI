using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using IT_RunCourseSecondPartAPI.Services.Service;
using IUserRepository = IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface.IUserRepository;

namespace IT_RunCourseSecondPartAPI;

public static class DependencyInjection
{
    public static IServiceCollection DependInjection(this IServiceCollection service)
    {
        service.AddSingleton<IUserRepository, IUserRepository>();
        service.AddSingleton<ICategoryRepository, CategoryRepository>();
        service.AddSingleton<IProductRepository, ProductRepository>();
        service.AddSingleton<IOrderRepository, OrderRepository>();
        service.AddSingleton<IOrderItemRepository, OrderItemRepository>();

        service.AddSingleton<IService<User>, UserService>();
        
        return service;
    }
}