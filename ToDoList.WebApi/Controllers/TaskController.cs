using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto createTaskDto)
        {
            
               await _taskService.AddTasks(createTaskDto);
                return Ok(new BaseResponse<object> { Message="Gorev Eklendi", IsSuccess=true});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var value= await _taskService.GetTaskById(id);
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTask(int id)
        {
           await _taskService.RemoveTask(id);
            return Ok(new BaseResponse<object> { IsSuccess = true, Message = $"{id}'li Kullanici Silindi" });
        }
        [HttpGet]
        public async Task<IActionResult> GetTaskList()
        {
            var value = await _taskService.GetTaskList();
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTasksDto updateTasksDto)
        {
            await _taskService.UpdateTask(updateTasksDto);
            return Ok(new BaseResponse<object> { IsSuccess = true, Message = "Task Guncellendi" });
        }

      

    

       

       
    }
}
