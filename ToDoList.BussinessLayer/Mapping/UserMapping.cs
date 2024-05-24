using AutoMapper;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.WebApi.Mapping
{
    public class UserMapping :Profile
    {
        public UserMapping()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, TodoList.Core.Dtos.UserDtos.ResultUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<GetUserRequest,GetUserRequestDto>().ReverseMap();
            CreateMap<User, GetUserRequestDto>().ReverseMap();


        }
    }
}
