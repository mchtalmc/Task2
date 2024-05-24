using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities;

namespace ToDoList.DataLayer.Concrete
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı dizesini burada ayarlayabilirsiniz

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=MÜCAHIT\\SQLEXPRESS;Initial Catalog=ToDoList;Integrated Security=True; TrustServerCertificate=True;");
        }

        // Veritabanındaki Users tablosunu temsil eden DbSet
        public DbSet<User> Users { get; set; }

        // Veritabanındaki Tasks tablosunu temsil eden DbSet
        public DbSet<Tasks> Tasks { get; set; }
    }
}
