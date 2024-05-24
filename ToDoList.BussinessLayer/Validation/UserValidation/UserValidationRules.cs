using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using ToDoList.DataLayer.Concrete;

namespace ToDoList.BussinessLayer.Validation.UserValidation
{
    public class UserValidationRules
    {
        private readonly ToDoContext _context;

        public UserValidationRules(ToDoContext context)
        {
            _context = context;
        }

        public  bool CheckUsername(string username)
        {
            bool iSThereUsername=  _context.Users.Any(u => u.Username == username);
            return iSThereUsername;
        }

        public bool CheckUserImageUrl(string userImageUrl)
        {
            bool isTehereUserImageUrl= _context.Users.Any(u => u.UserİmageUrl == userImageUrl);
            return isTehereUserImageUrl;
        }
        public bool CheckEmail(string email)
        {
            bool isThereEmail= _context.Users.Any(u => u.Email == email);
            return isThereEmail;
        }
    }
}
