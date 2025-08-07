using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.common;

namespace TaskManager.Infrastructure.repositories.project;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<Project?> GetProjectWithTasksAsync(Guid id);
}