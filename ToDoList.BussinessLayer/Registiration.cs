using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoList.BussinessLayer.Abstract;
using ToDoList.BussinessLayer.Concrete;
using ToDoList.BussinessLayer.Validation.TasksValidation;
using ToDoList.BussinessLayer.Validation.UserValidation;

namespace ToDoList.BussinessLayer
{
    public static class Registiration
    {
        // extension method for IServiceCollection  (advanced programing)
        public static void AddBusinessServies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddTransient<TasksValidationRules>();
            services.AddTransient<UserValidationRules>();


        }
    }
}
