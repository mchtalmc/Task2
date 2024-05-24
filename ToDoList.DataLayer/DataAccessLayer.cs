using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;
using ToDoList.DataLayer.EntityFramework;
using ToDoList.DataLayer.Repository;

namespace ToDoList.DataLayer
{
    public static class DataAccessLayer
    {
        public static void AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DB");
            services.AddDbContext<ToDoContext>(src => src.UseSqlServer(connectionString));


            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IUserRepository, UserRepostiroy>();
            services.AddScoped<IGenericRepository<Tasks>, GenericRepository<Tasks>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        }
    }
}
