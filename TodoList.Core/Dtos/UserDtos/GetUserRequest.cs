using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Dtos.UserDtos
{
    public class GetUserRequest
    {
        public string? Username { get; set; }
        public string? UserImageUrl { get; set; }
        public string?  Name { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
