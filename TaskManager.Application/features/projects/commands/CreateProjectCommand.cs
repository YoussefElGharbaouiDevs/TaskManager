using MediatR;
using TaskManager.Application.common;

namespace TaskManager.Application.features.projects.commands;

public record CreateProjectCommand(string Name) : IRequest<Result<Guid>>;