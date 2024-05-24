using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataLayer.Concrete;

namespace ToDoList.BussinessLayer.Validation.TasksValidation
{
    public class TasksValidationRules
    {
        private readonly ToDoContext _contex;

        public TasksValidationRules(ToDoContext contex)
        {
            _contex = contex;
        }

        public bool CheckTaskImageUrl (string taskUrl)
        {
            bool isThereTaskImageUrl=  _contex.Tasks.Any(u => u.TaskImageUrl == taskUrl);
            return isThereTaskImageUrl;
        }
        public bool CheckTasksName(string taskName)
        {
            bool isThereTaskname= _contex.Tasks.Any(u => u.TaskName == taskName);
            return isThereTaskname;
            
        }
    }
}
