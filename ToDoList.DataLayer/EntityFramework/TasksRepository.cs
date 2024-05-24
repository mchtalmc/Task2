using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Entities;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;
using ToDoList.DataLayer.Repository;

namespace ToDoList.DataLayer.EntityFramework
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        private readonly ToDoContext _context;
        public TasksRepository(ToDoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetTasksWithAnyParametrer(GetTaskRequest request)
        {
            if(request != null)
            {
                var query = _context.Tasks.AsQueryable();

                // Filter by Name
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.TaskName.Contains(request.Name));
                }

                // Filter by TaskStatus
                if (!string.IsNullOrEmpty(request.TaskStatus))
                {
                    query = query.Where(x => x.TaskStatus.ToString().Contains(request.TaskStatus));
                }

                // Filter by TaskType
                if (!string.IsNullOrEmpty(request.TaskType))
                {
                    query = query.Where(x => x.TaskType.ToString().Contains(request.TaskType));
                }

                // Filter by TaskImageUrl
                if (!string.IsNullOrEmpty(request.TaskImageUrl))
                {
                    query = query.Where(x => x.TaskImageUrl.Contains(request.TaskImageUrl));
                }

                // Apply pagination
                if (request.PageSize == 0) request.PageSize = 10;
                if(request.PageNumber==0) request.PageNumber = 1;
                var skip = (request.PageNumber - 1) * request.PageSize;
                var tasks = await query.Skip(skip).Take(request.PageSize).ToListAsync();

                return tasks;
            }
            var any= await _context.Tasks.ToListAsync();
            return any;
           
        }

            public async Task<List<Tasks>> GetTasksWithUserId(int id)
             {
            var value = await _context.Tasks.Where(t => t.UserId == id).ToListAsync();
            return value;
             }















        //public async Task<List<Tasks>> GetTasksWithTasksImageUrl(string? tasksImageUrl)
        //{

        //    var value = await _context.Tasks.Where(x => x.TaskImageUrl.Contains(tasksImageUrl)).ToListAsync();
        //    return value;
        //}
        //public async Task<List<Tasks>> GetTasksWithTasksName(string? name)
        //{
        //    var value= await _context.Tasks.Where(x => x.TaskName.ToLower().Contains(name)).ToListAsync();
        //    return value;
        //}
        //public async Task<List<Tasks>> GetTasksWithTasksStatus(string? tasksStatus)
        //{
        //    var value = await _context.Tasks.Where(x => x.TaskStatus.Equals(tasksStatus)).ToListAsync();
        //    return value;
        //}
        //public async Task<List<Tasks>> GetTasksWithTasksType(string? tasksType)
        //{
        //    var value = await _context.Tasks.Where(x => x.TaskType.Equals(tasksType)).ToListAsync();
        //    return value;
        //}
       

       
    }
}
