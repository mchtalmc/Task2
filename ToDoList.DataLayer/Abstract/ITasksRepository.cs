using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;

namespace ToDoList.DataLayer.Abstract
{
    public interface ITasksRepository : IGenericRepository<Tasks>
    {
        Task<List<Tasks>> GetTasksWithUserId(int id);
        Task<List<Tasks>> GetTasksWithAnyParametrer(GetTaskRequest request);


        //  Task<List<Tasks>> GetTasksWithTasksName(string? name);
        //  Task<List<Tasks>> GetTasksWithTasksImageUrl(string? tasksImageUrl);
        // Task<List<Tasks>> GetTasksWithTasksStatus(string? tasksStatus);
        // Task<List<Tasks>> GetTasksWithTasksType(string? tasksType);


    }
}
