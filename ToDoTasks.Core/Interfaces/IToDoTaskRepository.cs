using ToDoTasks.Core.Entities;

namespace ToDoTasks.Core.Interfaces
{
    public interface IToDoTaskRepository
    {
        IEnumerable<ToDoTask> GetAllTasks();
        
        Task<ToDoTask> GetTaskById(int id);

        Task CreateTask(ToDoTask toDoTask);

        Task<bool> UpdateTask(ToDoTask toDoTask);

        Task<bool> DeleteTask(int id);
    }
}
