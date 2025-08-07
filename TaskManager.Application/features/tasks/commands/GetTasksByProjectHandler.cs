using MediatR;
using TaskManager.Application.common;
using TaskManager.Infrastructure.repositories.Task;

namespace TaskManager.Application.features.tasks.commands;

public class GetTasksByProjectHandler : IRequestHandler<GetTasksByProjectQuery, Result<List<TaskDto>>>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksByProjectHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<List<TaskDto>>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetByProjectIdAsync(request.ProjectId);

        var dtoList = tasks.Select(t => new TaskDto(
            t.Id,
            t.Title,
            t.Description,
            t.Status.ToString(),
            t.Priority.ToString()
        )).ToList();

        return Result<List<TaskDto>>.Success(dtoList);
    }
}