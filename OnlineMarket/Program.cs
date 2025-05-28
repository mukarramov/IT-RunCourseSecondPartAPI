using FluentValidation;
using IT_RunCourseSecondPartAPI;
using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Mapper;
using IT_RunCourseSecondPartAPI.MinimalAPI.Extensions;
using IT_RunCourseSecondPartAPI.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.DependInjection();

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

// app.MapMinimalApis();

app.MapControllers();

app.Run();