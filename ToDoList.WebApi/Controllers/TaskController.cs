using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(true);
        }
        [HttpGet]
        public async Task<IActionResult> GetTaskList()
        {
          var values=   await _taskService.GetTaskList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var value = await _taskService.GetTaskById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTask(int id)
        {
            await _taskService.RemoveTask(id);
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            await _taskService.UpdateTask(updateTaskDto);
            return Ok(true);
        }

       
    }
}
