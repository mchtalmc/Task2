﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace ToDoList.DataLayer.Abstract
{
    public interface ITaskDal : IGenericDal<Tasks>
    {
        
    }
}
