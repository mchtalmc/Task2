using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace TodoList.Core.Dtos.TaskDto
{
    public class UpdateTasksDto : BaseTaskRequest
    {
        public int TasksId { get; set; }
    }
}
