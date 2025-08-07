using MediatR;
using TaskManager.Application.common;
using TaskManager.Infrastructure.repositories.project;

namespace TaskManager.Application.features.projects.queries;

public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, Result<List<ProjectDto>>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<List<ProjectDto>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();
        var dtoList = projects.Select(p => new ProjectDto(p.Id, p.Name)).ToList();
        return Result<List<ProjectDto>>.Success(dtoList);
    }
}