using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataLayer.Abstract
{
    public interface IGenericDal<T> 
    {
        Task<bool> Add(T entity);
        Task<bool> Remove(T entity);
        Task<bool> Update(T Entity);
        Task<T> TGet(int id);
        Task<List<T>> GetList();
    }
}
