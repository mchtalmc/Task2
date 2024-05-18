using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;
using ToDoList.DataLayer.Repository;

namespace ToDoList.DataLayer.EntityFramework
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public EfUserDal(ToDoContext context) : base(context)
        {
        }
    }
}
