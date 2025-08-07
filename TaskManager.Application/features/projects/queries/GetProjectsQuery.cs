using MediatR;
using TaskManager.Application.common;

namespace TaskManager.Application.features.projects.queries;

public record GetProjectsQuery() : IRequest<Result<List<ProjectDto>>>;

public record ProjectDto(Guid Id, string Name);