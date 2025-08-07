using MediatR;
using TaskManager.Application.common;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.repositories.Task;

namespace TaskManager.Application.features.tasks.commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<Guid>>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem(request.Title, request.Description, request.Priority, request.ProjectId);
        await _taskRepository.AddAsync(task);
        await _taskRepository.SaveChangesAsync();
        return Result<Guid>.Success(task.Id);
    }
}