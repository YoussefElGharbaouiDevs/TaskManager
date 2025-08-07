using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.common;

namespace TaskManager.Infrastructure.repositories.Task;

public interface ITaskRepository : IGenericRepository<TaskItem>
{
    Task<List<TaskItem>> GetByProjectIdAsync(Guid projectId);
}