﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Entities

{
    
    public class Tasks
    {
        
        public int TasksId { get; set; }
        public string TaskName { get; set; }
        public string TaskImageUrl { get; set; }
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime StartedDate { get; set; }= DateTime.Now;
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public TaskType TaskType { get; set; }
        public int UserId { get; set; }
       






    }
}
