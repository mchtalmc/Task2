using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;

namespace ToDoList.BussinessLayer.Abstract
{
    public interface ITaskService
    {
        Task<BaseResponse<object>>  AddTasks(CreateTaskDto createTaskDto);
        Task<BaseResponse<object>> UpdateTask(UpdateTasksDto updateTasksDto);
        Task<BaseResponse<object>> RemoveTask(int id);
        Task<BaseResponse<ResultTaskDto>> GetTaskById(int id);
        Task<BaseResponse<List<ResultTaskDto>>> GetTaskList();
    }
}
