using FluentValidation;
using ToDoTasks.Core.DTOs;

namespace ToDoTasks.Infraestructure.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Code)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5);

            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(50);
        }
    }
}
