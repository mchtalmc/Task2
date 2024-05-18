using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TodoList.Core.Entities;



namespace TodoList.Core.Dtos.TaskDto
{
    public class CreateTaskDto
    {

        
        public string TaskName { get; set; }
        public string TaskImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Entities.TaskStatus TaskStatus { get; set; }
        public TaskType TaskType { get; set; }
        public int UserId { get; set; }

    }
}
