using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.BussinessLayer.Abstract
{
    public interface IUserService
    {
        Task<BaseResponse<object>> AddUser(CreateUserDto createUserDto);
        Task<BaseResponse<object>> DeleteUser(int id);
        Task<BaseResponse<object>> UpdateUser(UpdateUserDto  updateUserDto);
        Task<BaseResponse<ResultUserDto>> GetUserById(int id);
        Task<BaseResponse<List<GetUserRequestDto>>> GetUserAnyParemetrer (GetUserRequest request);







        //Task<BaseResponse<List<ResultUserDto>>> GetAll();

     //   Task<BaseResponse<List<ResultUserDto>>> GetUserWithUserName(string? username);
      //  Task<BaseResponse<List<ResultUserDto>>> GetUserByAge(int? id);
      //  Task<BaseResponse<ResultUserDto>> GetUserByEmail(string? email);
      //  Task<BaseResponse<List<ResultUserDto>>> GetUserByName(string? name);
      //  Task<BaseResponse<List<ResultUserDto>>> GetUserByUserImageUrl(string? userImageUrl);
        
        
        
       
    }
}
