using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Dtos.TaskDto
{
    public class GetTaskRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TaskImageUrl { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskType { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
