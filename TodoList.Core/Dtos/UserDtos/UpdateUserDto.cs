using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserİmageUrl { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
