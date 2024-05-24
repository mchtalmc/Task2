﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace TodoList.Core.Dtos.UserDtos
{
    public class ResultUserDto 
    {
        public string Username { get; set; }
        public string UserİmageUrl { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; }


    }
    public class GetUserResponseDto
    {
        public string Username { get; set; }
        public string UserİmageUrl { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; }
    }
}
