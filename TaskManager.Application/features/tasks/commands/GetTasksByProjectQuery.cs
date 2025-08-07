using MediatR;
using TaskManager.Application.common;

namespace TaskManager.Application.features.tasks.commands;

public record GetTasksByProjectQuery(Guid ProjectId) : IRequest<Result<List<TaskDto>>>;

public record TaskDto(Guid Id, string Title, string? Description, string Status, string Priority);