using MediatR;
using TaskManager.Application.common;
using TaskManager.Infrastructure.repositories.Task;

namespace TaskManager.Application.features.tasks.commands;

public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, Result<bool>>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskStatusCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<bool>> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId);

        if (task == null)
            return Result<bool>.Failure("Task not found.");

        task.UpdateStatus(request.Status);

        _taskRepository.Update(task);
        await _taskRepository.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}