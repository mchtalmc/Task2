using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.BussinessLayer.Abstract
{
    public interface IUserService
    {
        Task<bool> AddUser(CreateUserDto createUserDto);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdateUser(UpdateUserDto  updateUserDto);
        Task<List<ResultUserDto>> GetAll();
        Task<ResultUserDto> GetUserById(int id);

    }
}
