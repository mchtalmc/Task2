using AutoMapper;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;
using ToDoList.BussinessLayer.Validation.TasksValidation;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.BussinessLayer.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITasksRepository _taskDal;
        private readonly IMapper _mapper;
        private readonly TasksValidationRules _rules;

        public TaskManager(ITasksRepository taskDal, IMapper mapper, TasksValidationRules rules)
        {
            _taskDal = taskDal;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<BaseResponse<object>> AddTasks(CreateTaskDto createTaskDto)
        {
            if (_rules.CheckTasksName(createTaskDto.TaskName))
            {
                return new BaseResponse<object> { Message = "Taskname ile kayit yapilmis, Farkli bir taskname giriniz", IsSuccess = false };
            }
            if(_rules.CheckTaskImageUrl(createTaskDto.TaskImageUrl))
            {
                return new BaseResponse<object> { Message="TasksImageUrl ile kayit yapilmis , Farkli bir Userimage giriniz",IsSuccess = false };    
            }
            await _taskDal.Add(_mapper.Map < Tasks > (createTaskDto));
            return new BaseResponse<object> { IsSuccess= true , Message="Kayit Basarili"};
        }

        public async Task<BaseResponse<ResultTaskDto>> GetTaskById(int id)
        {
            if(id != null)
            {
                var value = await _taskDal.TGet(id);
                var response= _mapper.Map<ResultTaskDto>(value);
                return new BaseResponse<ResultTaskDto> { IsSuccess = true, Message = $"{id} Kayitli Gorev", Data = response };
            }
            return new BaseResponse<ResultTaskDto> { Message = $"{id}'li Kullanici Bulunamadi",IsSuccess = false };
            
        }

        public async Task<BaseResponse<List<ResultTaskDto>>> GetTaskList()
        {
               var value = await _taskDal.GetList();
            var response= _mapper.Map<List<ResultTaskDto>>(value);
            return new BaseResponse<List<ResultTaskDto>> {  Message="Gorev Listesi",Data = response};
        }
        public async Task<BaseResponse<object>> RemoveTask(int id)
        {
            if (id != null)
            {
                var value = await _taskDal.TGet(id);
                bool isDelete = await _taskDal.Remove(value);
                return new BaseResponse<object> { IsSuccess = isDelete, Message = $"{id}'li Basarili bir sekilde kaldirildi" };
            }
            return new BaseResponse<object> { IsSuccess = false, Message = $"{id}' li Kullanici Bulunamadi" };

        }

        public async Task<BaseResponse<object>> UpdateTask(UpdateTasksDto updateTasksDto)
        {
            await _taskDal.Update(_mapper.Map<Tasks>(updateTasksDto));
            return new BaseResponse<object> {  Message = "Guncellendi" };
        }
        public async Task<BaseResponse<List<ResultTaskDto>>> GetTaskWithUserById(int userId)
        {
            if (userId != null)
            {
                var value = await _taskDal.GetTasksWithUserId((userId));
                var response = _mapper.Map<List<ResultTaskDto>>(value);
                return new BaseResponse<List<ResultTaskDto>> { Message = $"{userId} Kayitli Kullanici", Data = response };
            }
            return new BaseResponse<List<ResultTaskDto>> { Message = " Kullanici Bulunamadi" };
        }

        public async Task<BaseResponse<List<GetTaskRequestDto>>> GetTaskWithAnyParemetre(GetTaskRequest request)
        {
            var values = await _taskDal.GetTasksWithAnyParametrer(request);
          

            if (values != null || !values.Any())
            {
                var response =  _mapper.Map<List<GetTaskRequestDto>>(values);
                return new BaseResponse<List<GetTaskRequestDto>>
            {
                Data = response,
                IsSuccess = true,
                Message = "Filtreleme sonucu"
            };

         }
            return new BaseResponse<List<GetTaskRequestDto>>
            {
                IsSuccess = false,
                Message = "Filtrelemeyle eşleşen veri yok"
            };




        }










        //public async Task<BaseResponse<List<ResultTaskDto>>> GetTasksWithTasksImageUrl(string? tasksImageUrl)
        //{
        //    if (!string.IsNullOrEmpty(tasksImageUrl))
        //    {
        //        var value = await _taskDal.GetTasksWithTasksImageUrl(tasksImageUrl);
        //        var response = _mapper.Map<List<ResultTaskDto>>(value);
        //        return new BaseResponse<List<ResultTaskDto>> { Data = response, Message = $"{tasksImageUrl}'li Tasks'lar" };
        //    }
        //    return new BaseResponse<List<ResultTaskDto>> { Message= $"{tasksImageUrl}'li Kullanici bulunamadi", IsSuccess = false };
        //}

        //public async Task<BaseResponse<List<ResultTaskDto>>> GetTasksWithTasksName(string? name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        var value = await _taskDal.GetTasksWithTasksName(name);
        //        var response = _mapper.Map<List<ResultTaskDto>>(value);
        //        return new BaseResponse<List<ResultTaskDto>> { Data = response, Message = $"{name}'li Kullanicilar" };
        //    }
        //    return new BaseResponse<List<ResultTaskDto>> { IsSuccess = false, Message = $"{name}'li Kullanici bulunumadi" };

        //}

        //public async Task<BaseResponse<List<ResultTaskDto>>> GetTasksWithTasksStatus(string? tasksStatus)
        //{
        //    if (!string.IsNullOrEmpty(tasksStatus))
        //    {
        //    var value = await _taskDal.GetTasksWithTasksStatus(tasksStatus);
        //    var response = _mapper.Map<List<ResultTaskDto>>(value);
        //    return new BaseResponse<List<ResultTaskDto>> { Message = $"{tasksStatus}'li Taskslar", Data = response };
        //    }
        //    return new BaseResponse<List<ResultTaskDto>> { IsSuccess = false, Message =$"{tasksStatus}'li Kullanici Bulunamadi" };
        //}

        //public async Task<BaseResponse<List<ResultTaskDto>>> GetTasksWithTasksType(string? tasksType)
        //{
        //    if(!string.IsNullOrEmpty(tasksType))
        //    {
        //    var value = await _taskDal.GetTasksWithTasksType(tasksType);
        //    var response = _mapper.Map<List<ResultTaskDto>>(value);
        //    return new BaseResponse<List<ResultTaskDto>> { Data = response, Message = $"{tasksType}'li Taskslar" };
        //    }
        //    return new BaseResponse<List<ResultTaskDto>> { IsSuccess = false, Message = $"{tasksType}'li Kullanici Bulunamadi" };

        //}


    }
}
