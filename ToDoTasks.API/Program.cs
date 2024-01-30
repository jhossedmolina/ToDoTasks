using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using ToDoTasks.Core.DTOs;
using ToDoTasks.Core.Interfaces;
using ToDoTasks.Core.Services;
using ToDoTasks.Infraestructure.Data;
using ToDoTasks.Infraestructure.Data.Configurations;
using ToDoTasks.Infraestructure.Mappings;
using ToDoTasks.Infraestructure.Repositories;
using ToDoTasks.Infraestructure.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
builder.Services.AddScoped<IToDoTaskService, ToDoTaskService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<ToDoTasksInMemoryContext>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ToDoTaskDto>, ToDoTaskValidator>();
builder.Services.AddScoped<IValidator<CategoryDto>, CategoryValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
