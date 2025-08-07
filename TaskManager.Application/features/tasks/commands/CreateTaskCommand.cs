using MediatR;
using TaskManager.Application.common;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.features.tasks.commands;

public record CreateTaskCommand(string Title, string? Description, Priority Priority, Guid ProjectId)
    : IRequest<Result<Guid>>;