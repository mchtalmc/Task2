using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //Login Sarti
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTask(CreateTaskDto createTaskDto)
        {
            
               await _taskService.AddTasks(createTaskDto);
                return Ok();
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var value= await _taskService.GetTaskById(id);
            return Ok(value);
        }
        [HttpDelete("removetask")]
        public async Task<IActionResult> RemoveTask(int id)
        {
           await _taskService.RemoveTask(id);
            return Ok();
        }
        [HttpGet("tasklist")]
        public async Task<IActionResult> GetTaskList()
        {
            var value = await _taskService.GetTaskList();
            return Ok(value);
        }
        [HttpGet("{userId}/userId")]
        public async Task<IActionResult> GetTaskByUserId(int userId)
        {
            var value= await _taskService.GetTaskWithUserById(userId);
            return Ok(value);
        }
        [HttpPut("updatetask")]
        public async Task<IActionResult> UpdateTask(UpdateTasksDto updateTasksDto)
        {
            await _taskService.UpdateTask(updateTasksDto);
            return Ok();
        }
        [HttpGet("anyfilter")]
        public async Task<IActionResult> GetUserByAnyFilter([FromQuery]GetTaskRequest taskRequest)
        {
           var values=  await _taskService.GetTaskWithAnyParemetre(taskRequest);
            return Ok(values);
        }











        //[HttpGet("{name}/taskName")]
        //public async Task<IActionResult> GetTasksWithByTasksName(string name)
        //{
        //    var value = await _taskService.GetTasksWithTasksName(name);
        //    return Ok(value);
        //}
        //[HttpGet("{taskImageUrl}/taskImageUrl")]
        //public  async Task<IActionResult> GetTaskWithTaskImageUrl(string taskImageUrl)
        //{
        //    var value = await _taskService.GetTasksWithTasksImageUrl(taskImageUrl);
        //    return Ok(value);
        //}
        //[HttpGet("{taskStatus}/taskStatus")]
        //public async Task<IActionResult> GetTaskByTaskStatus(string taskStatus)
        //{
        //    var value= await _taskService.GetTasksWithTasksStatus(taskStatus);
        //    return Ok(value);
        //}
        //[HttpGet("{taskType}/taskType")]
        
        //public async Task<IActionResult> GetTasksWithTasksType(string taskType)
        //{
        //    var value = await _taskService.GetTasksWithTasksType(taskType);
        //    return Ok(value);
        //}









    }
}
