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
        [Required(ErrorMessage ="Lutfen Username Giriniz")]
        [MaxLength(50,ErrorMessage ="50 karakterden uzun olamaz")]
        
        public string Username { get; set; }

        public string UserİmageUrl { get; set; }
        [Required(ErrorMessage ="Lutfen name giriniz")]

        public string Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage ="Email formatinda giris yapiniz.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; }

    }
}
