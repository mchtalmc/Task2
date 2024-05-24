using Microsoft.EntityFrameworkCore;
using TodoList.Core.Dtos.UserDtos;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;

namespace ToDoList.DataLayer.Repository;


public class GenericRepository<T> : IGenericRepository<T> where T : class
{
   

    //Contex'le baglanti kurup methodlari tamamla
    private readonly ToDoContext _context;

    public GenericRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<T>> GetList()
    {
        var values= await _context.Set<T>().ToListAsync();
        return values;
    }

   

    public async Task<bool> Remove(T entity)
    {
         _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<T> TGet(int? id)
    {
        var value= await _context.Set<T>().FindAsync(id);
        return value;
    }

    public async Task<bool> Update(T Entity)
    {
        _context.Update(Entity);
        await _context.SaveChangesAsync();
        return true;
    }

   
}

