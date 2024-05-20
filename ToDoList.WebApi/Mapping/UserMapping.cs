using AutoMapper;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.WebApi.Mapping
{
    public class UserMapping :Profile
    {
        public UserMapping()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
