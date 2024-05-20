using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace TodoList.Core.Dtos.UserDtos
{
    public class ResultUserDto :BaseUserResponse
    {
        public int UserId { get; set; }

        public DateTime CreatedDate { get; }


    }
}
