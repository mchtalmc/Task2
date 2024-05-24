using System.ComponentModel.DataAnnotations;
using TodoList.Core.Entities;

namespace TodoList.Core.Dtos.TaskDto
{
    public class BaseTaskRequest
    {
        [Required(ErrorMessage ="Taskname ' i belirtiniz")]
        [StringLength(50,ErrorMessage ="50 Karekterden buyuk olamaz")]
       
        public string TaskName { get; set; }
        public string TaskImageUrl { get; set; }
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime StartedDate { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        [Range(1,4)]
        public System.Threading.Tasks.TaskStatus TaskStatus { get; set; }
        [Range(1,7)]
        public TaskType TaskType { get; set; }
        public  int UserId { get; set; }



    }
}
