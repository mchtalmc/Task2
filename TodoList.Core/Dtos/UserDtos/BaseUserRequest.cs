using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Dtos.UserDtos
{
    public class BaseUserRequest
    {
        public string Username { get; set; }
        public string UserİmageUrl { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
