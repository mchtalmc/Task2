using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
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

        public async Task<BaseResponse<object>> AddTasks(CreateTaskDto createTaskDto)
        {
            await _taskDal.Add(_mapper.Map < Tasks > (createTaskDto));
            return new BaseResponse<object> { IsSuccess= true , Message="Kayit Basarili"};
        }

        public async Task<BaseResponse<ResultTaskDto>> GetTaskById(int id)
        {
            var value = await _taskDal.TGet(id);
            var response= _mapper.Map<ResultTaskDto>(value);
            return new BaseResponse<ResultTaskDto> { IsSuccess = true, Message = $"{id} Kayitli Gorev", Data = response };
        }

        public async Task<BaseResponse<List<ResultTaskDto>>> GetTaskList()
        {
            var value = await _taskDal.GetList();
            var response= _mapper.Map<List<ResultTaskDto>>(value);
            return new BaseResponse<List<ResultTaskDto>> { IsSuccess = true, Message="Gorev Listesi",Data = response};
        }

        public async Task<BaseResponse<object>> RemoveTask(int id)
        {
            var value = await _taskDal.TGet(id);
            bool isDelete = await _taskDal.Remove(value);
            return new BaseResponse<object> { IsSuccess = isDelete, Message = $"{id}'li Basarili bir sekilde kaldirildi" };
        }

        public async Task<BaseResponse<object>> UpdateTask(UpdateTasksDto updateTasksDto)
        {
            await _taskDal.Update(_mapper.Map<Tasks>(updateTasksDto));
            return new BaseResponse<object> { IsSuccess = true, Message = "Guncellendi" };
        }
    }
}
