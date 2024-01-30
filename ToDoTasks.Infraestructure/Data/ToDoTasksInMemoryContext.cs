using Microsoft.EntityFrameworkCore;
using ToDoTasks.Core.Entities;
using ToDoTasks.Infraestructure.Data.Configurations;

namespace ToDoTasks.Infraestructure.Data
{
    public class ToDoTasksInMemoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ToDoTasksDB");
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoTaskConfiguration).Assembly);
        }
    }
}
