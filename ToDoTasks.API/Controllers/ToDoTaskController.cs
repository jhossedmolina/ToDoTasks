using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTasks.Core.DTOs;
using ToDoTasks.Core.Entities;
using ToDoTasks.Core.Interfaces;

namespace ToDoTasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly IMapper _mapper;

        public ToDoTaskController(IToDoTaskService toDoTaskService, IMapper mapper)
        {
            _toDoTaskService = toDoTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ToDoTaskDto>> GetTasks()
        {
            var tasks = _toDoTaskService.GetAllTasks();
            var tasksDto = _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var task = await _toDoTaskService.GetTaskById(id);
            var taskDto = _mapper.Map<ToDoTaskDto>(task);
            if (taskDto is null)
                return NotFound();
            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(ToDoTaskDto toDoTaskDto)
        {
            var task = _mapper.Map<ToDoTask>(toDoTaskDto);
            await _toDoTaskService.CreateTask(task);
            toDoTaskDto = _mapper.Map<ToDoTaskDto>(task);
            return CreatedAtAction(nameof(GetTaskById), new {id = toDoTaskDto.Id}, toDoTaskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, ToDoTaskDto toDoTaskDto)
        {
            var getTaskById = await _toDoTaskService.GetTaskById(id);
            if (getTaskById is null)
                return NotFound();

            var toDoTask = _mapper.Map<ToDoTask>(toDoTaskDto);
            toDoTask.Id = id;
            await _toDoTaskService.UpdateTask(toDoTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var getTaskById = await _toDoTaskService.GetTaskById(id);
            if (getTaskById is null)
                return NotFound();

            await _toDoTaskService.DeleteTask(id);
            return NoContent();
        }
    }
}
