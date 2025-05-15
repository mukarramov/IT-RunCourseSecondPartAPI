using FluentValidation;
using IT_RunCourseSecondPartAPI.Mapper;
using IT_RunCourseSecondPartAPI.MinimalAPI.Extensions;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using IT_RunCourseSecondPartAPI.Services.Service;
using IT_RunCourseSecondPartAPI.Validations;
using IUserRepository = IT_RunCourseSecondPartAPI.Repositories.Interface.IUserRepository;
using UserRepository = IT_RunCourseSecondPartAPI.Repositories.Repository.UserRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services
    .AddSingleton<IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface.IUserRepository, UserRepositoryGenetic>();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IOrderItemRepository, OrderItemRepository>();

builder.Services.AddSingleton<IService<User>, Service>();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => { x.AddMaps(typeof(UserProfile).Assembly); });

builder.Services.AddMapster();
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapMinimalApis();

app.MapControllers();

app.Run();