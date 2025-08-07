using MediatR;
using TaskManager.Application.common;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.repositories.project;

namespace TaskManager.Application.features.projects.commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Name);

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return Result<Guid>.Success(project.Id);
    }
}