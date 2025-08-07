using FluentValidation;
using TaskManager.Application.features.tasks.commands;

namespace TaskManager.Application.features.tasks.validators;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Task title is required.")
            .MaximumLength(200).WithMessage("Title too long.");
    }
}