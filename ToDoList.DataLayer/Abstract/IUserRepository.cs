using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;

namespace ToDoList.DataLayer.Abstract
{
    public interface IUserRepository :IGenericRepository<User>
    {

        Task<List<User>> GetUserByAnyParametrer(GetUserRequest request);


        //Task<List<User>> GetUserList();
        // Task<List<User>> GetUserByUsername(string? username);
        // Task<List<User>> GetUserByUserImageUrl(string? userImageUrl);
        //  Task<List<User>> GetUserByName(string? name);
        //  Task<List<User>> GetUserByAge(int? age);
        //   Task<List<User>> GetUserByEmail(string? email);
        // Task<List<User>> GetUserWithHasAnyParemtrer(string? username, string? userImageUrl, string? name, int? age, string? email ) ;
    }
}
