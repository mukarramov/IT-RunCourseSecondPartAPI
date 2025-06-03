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
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<IOrderRepository, OrderRepository>();
        service.AddScoped<IOrderItemRepository, OrderItemRepository>();

        service.AddScoped<IUserService, UserService>();
        service.AddScoped<ICategoryService, CategoryService>();
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<IOrderService, OrderService>();
        service.AddScoped<IOrderItemService, OrderItemService>();

        return service;
    }
}