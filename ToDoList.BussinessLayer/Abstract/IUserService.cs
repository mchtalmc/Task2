using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.BussinessLayer.Abstract
{
    public interface IUserService
    {
        Task<BaseResponse<object>> AddUser(CreateUserDto createUserDto);
        Task<BaseResponse<object>> DeleteUser(int id);
        Task<BaseResponse<object>> UpdateUser(UpdateUserDto  updateUserDto);
        Task<BaseResponse<List<ResultUserDto>>> GetAll();
        Task<BaseResponse<ResultUserDto>> GetUserById(int id);

    }
}
