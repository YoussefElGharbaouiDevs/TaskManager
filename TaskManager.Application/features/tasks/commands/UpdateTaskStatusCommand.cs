using MediatR;
using TaskManager.Application.common;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.features.tasks.commands;

public record UpdateTaskStatusCommand(Guid TaskId, Status Status) : IRequest<Result<bool>>;
