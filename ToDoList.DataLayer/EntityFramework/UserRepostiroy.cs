using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;
using ToDoList.DataLayer.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ToDoList.DataLayer.EntityFramework
{
    public class UserRepostiroy : GenericRepository<User>, IUserRepository
    {
        private readonly ToDoContext _context;

        public UserRepostiroy(ToDoContext context) : base(context)
        {
            _context = context;
        }

        //GetUserRequest sınıf oluşturalım içerisine -> Controllerdan bunu alalım burada sadece sınıf olsun string? username, string? userImageUrl, string? name, int? age, string? email +
        // String alanların tamamı öncelikle küçük karaktere çevrilmeli ve contains methodu ile yani içeren şeklinde geliştirilmelidir. +
        public async Task<List<User>> GetUserByAnyParametrer(GetUserRequest request) // Istenilen parametreye gore donen + // Pagination GetUserRequest icerisinde.
        {
            if (request != null)
            {
                var query = _context.Users.AsQueryable();

                // Filter by Username
                if (!string.IsNullOrEmpty(request.Username))
                {
                    query = query.Where(u => u.Username.ToLower().Contains(request.Username.ToLower()));
                }

                // Filter by UserImageUrl
                if (!string.IsNullOrEmpty(request.UserImageUrl))
                {
                    query = query.Where(u => u.UserİmageUrl.ToLower().Contains(request.UserImageUrl.ToLower()));
                }

                // Filter by Name
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(u => u.Name.ToLower().Contains(request.Name.ToLower()));
                }

                // Filter by Age
                if (request.Age != null)
                {
                    query = query.Where(u => u.Age == request.Age.Value);
                }

                // Filter by Email
                if (!string.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(u => u.Email.ToLower().Contains(request.Email.ToLower()));
                }

                // Apply pagination
                if (request.PageSize == 0)
                    request.PageSize = 10;

                if (request.PageNumber == 0)
                    request.PageNumber = 1;

                var skip = (request.PageNumber - 1) * request.PageSize;
                var users = await query.Skip(skip).Take(request.PageSize).ToListAsync();

                return users;
            }
            var any = await _context.Users.ToListAsync();
            return any;


        }


















        //public async Task<List<User>> GetUserList()
        //{
        //    var value = await _context.Users.ToListAsync();
        //    return value;
        //}
        //public async Task<List<User>> GetUserByEmail(string? email)
        //{
        //    var value = await _context.Users.Where(x => x.Email.ToLower().Contains(email.ToLower())).ToListAsync();
        //    return value;
        //}

        //public async Task<List<User>> GetUserByName(string? name)
        //{
        //    var value = await _context.Users.Where(x => x.Username.ToLower().Contains(name.ToLower())).ToListAsync();
        //    return value;
        //}

        //public async Task<List<User>> GetUserByUserImageUrl(string? userImageUrl)
        //{
        //    var value = await _context.Users.Where(x => x.UserİmageUrl.ToLower().Contains(userImageUrl.ToLower())).ToListAsync();
        //    return value;
        //}

        //public async Task<List<User>> GetUserByUsername(string? username)
        //{
        //    var values = await _context.Users.Where(x => x.Username.ToLower().Contains(username.ToLower())).ToListAsync();
        //    return values;
        //}
        //public async Task<List<User>> GetUserByAge(int? age)
        //{
        //    var value = await _context.Users.Where(x => x.Age.Equals(age)).ToListAsync();
        //    return value;
        //}


    }
}
