using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.common;

namespace TaskManager.Infrastructure.repositories.Task;

public class TaskRepository : GenericRepository<TaskItem>, ITaskRepository
{
    private readonly TaskManagerDbContext _context;
    public TaskRepository(TaskManagerDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<TaskItem>> GetByProjectIdAsync(Guid projectId)
        => await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
}