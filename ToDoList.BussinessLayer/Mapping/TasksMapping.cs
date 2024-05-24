using AutoMapper;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;

namespace ToDoList.WebApi.Mapping
{
    public class TasksMapping :Profile
    {
        public TasksMapping()
        {
            CreateMap<Tasks, CreateTaskDto>().ReverseMap();
            CreateMap<Tasks, UpdateTasksDto>().ReverseMap();
            CreateMap<Tasks, ResultTaskDto>().ReverseMap();
            CreateMap<GetTaskRequest,GetTaskRequestDto>().ReverseMap();
            CreateMap<Tasks, GetTaskRequestDto>().ReverseMap();
        }
    }
}
