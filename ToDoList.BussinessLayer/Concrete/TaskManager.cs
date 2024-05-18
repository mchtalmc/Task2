using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.EntityFramework;

namespace ToDoList.BussinessLayer.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskDal _taskDal;
        private readonly IMapper _mapper;

        public TaskManager(ITaskDal taskDal, IMapper mapper)
        {
            _taskDal = taskDal;
            _mapper = mapper;
        }

        public async Task<bool> AddTasks(CreateTaskDto createTaskDto)
        {
            await _taskDal.Add(_mapper.Map<Tasks>(createTaskDto));
            return true;
        }

        public async Task<bool> RemoveTask(int id)
        {
            var value = await _taskDal.TGet(id);
            await _taskDal.Remove(value);
            return true;
        }

        public async Task<bool> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            await _taskDal.Update(_mapper.Map<Tasks>(updateTaskDto));
            return true;
        }

        public async Task<List<ResultTaskDto>> GetTaskList()
        {
            var entity= await _taskDal.GetList();
            var value= _mapper.Map<List<ResultTaskDto>>(entity);
            return value;
        }

        public async Task<ResultTaskDto> GetTaskById(int id)
        {
            var value = await _taskDal.TGet(id);
            return _mapper.Map<ResultTaskDto>(value);
        }
    }
}
