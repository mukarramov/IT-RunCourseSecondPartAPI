using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using IT_RunCourseSecondPartAPI.Services.Service;

namespace IT_RunCourseSecondPartAPI;

public static class DependencyInjection
{
    public static IServiceCollection DependInjection(this IServiceCollection service)
    {
        service.AddSingleton<IRepository<User>, UserRepository>();
        service.AddSingleton<IRepository<Category>, CategoryRepository>();
        service.AddSingleton<IRepository<Product>, ProductRepository>();
        service.AddSingleton<IRepository<Order>, OrderRepository>();
        service.AddSingleton<IRepository<OrderItem>, OrderItemRepository>();

        service.AddSingleton<IService<User>, UserService>();
        service.AddSingleton<IService<Category>, CategoryService>();
        service.AddSingleton<IService<Product>, ProductService>();
        service.AddSingleton<IService<Order>, OrderService>();
        service.AddSingleton<IService<OrderItem>, OrderItemService>();

        return service;
    }
}