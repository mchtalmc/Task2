using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace TodoList.Core.Dtos.UserDtos
{
    public class UpdateUserDto : BaseUserRequest
    {
        public int UserId { get; set; }

    }
}
