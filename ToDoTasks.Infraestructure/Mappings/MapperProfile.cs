using AutoMapper;
using ToDoTasks.Core.DTOs;
using ToDoTasks.Core.Entities;

namespace ToDoTasks.Infraestructure.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ToDoTask, ToDoTaskDto>();
            CreateMap<ToDoTaskDto, ToDoTask>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
