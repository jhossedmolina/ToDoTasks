using ToDoTasks.Core.Entities;
using ToDoTasks.Core.Interfaces;
using ToDoTasks.Infraestructure.Data;

namespace ToDoTasks.Infraestructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private ToDoTasksInMemoryContext _context;

        public ToDoTaskRepository(ToDoTasksInMemoryContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return _context.ToDoTasks.ToList();
        }

        public async Task<ToDoTask> GetTaskById(int id)
        {
            return await _context.ToDoTasks.FindAsync(id);
        }

        public async Task CreateTask(ToDoTask toDoTask)
        {
            _context.ToDoTasks.Add(toDoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTask(ToDoTask toDoTask)
        {
            var currentTask = await GetTaskById(toDoTask.Id);
            currentTask.IdCategory = toDoTask.IdCategory;
            currentTask.Description = toDoTask.Description;
            currentTask.Date = toDoTask.Date;
            currentTask.StartDateTime = toDoTask.StartDateTime;
            currentTask.EndDateTime = toDoTask.EndDateTime;
            currentTask.Time = toDoTask.Time;

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        
        public async Task<bool> DeleteTask(int id)
        {
            var currentTask = await GetTaskById(id);
            _context.ToDoTasks.Remove(currentTask);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
