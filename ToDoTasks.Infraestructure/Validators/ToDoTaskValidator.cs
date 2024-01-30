using FluentValidation;
using ToDoTasks.Core.DTOs;

namespace ToDoTasks.Infraestructure.Validators
{
    public class ToDoTaskValidator : AbstractValidator<ToDoTaskDto>
    {
        public ToDoTaskValidator()
        {
            RuleFor(toDoTask => toDoTask.IdCategory)
                .NotNull()
                .NotEmpty();

            RuleFor(toDoTask => toDoTask.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);
        }
    }
}
