using FluentValidation;
using IT_RunCourseSecondPartAPI;
using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Interceptors;
using IT_RunCourseSecondPartAPI.Mapper;
using IT_RunCourseSecondPartAPI.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddOpenApi();

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(databaseConnectionString));


builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.UseNpgsql(databaseConnectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .AddInterceptors(sp.GetRequiredService<SaveChangeInterceptor>());
});

builder.Services.DependInjection();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => { x.AddMaps(typeof(MapperProfile).Assembly); });

builder.Services.AddValidatorsFromAssemblyContaining<UserCreateValidation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();