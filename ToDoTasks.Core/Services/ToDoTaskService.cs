using ToDoTasks.Core.Entities;
using ToDoTasks.Core.Interfaces;

namespace ToDoTasks.Core.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return _toDoTaskRepository.GetAllTasks();
        }

        public async Task<ToDoTask> GetTaskById(int id)
        {
            return await _toDoTaskRepository.GetTaskById(id);
        }

        public async Task CreateTask(ToDoTask toDoTask)
        {
            await _toDoTaskRepository.CreateTask(toDoTask);
        }

        public async Task<bool> UpdateTask(ToDoTask toDoTask)
        {
            return await _toDoTaskRepository.UpdateTask(toDoTask);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _toDoTaskRepository.DeleteTask(id);
        }
    }
}
