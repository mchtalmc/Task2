using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;

namespace ToDoList.BussinessLayer.Abstract
{
    public interface ITaskService
    {
        Task<bool> AddTasks(CreateTaskDto createTaskDto);
        Task<bool> UpdateTask(UpdateTaskDto updateTaskDto);
        Task<bool> RemoveTask(int id);
        Task<ResultTaskDto> GetTaskById(int id);
        Task<List<ResultTaskDto>> GetTaskList();
    }
}
