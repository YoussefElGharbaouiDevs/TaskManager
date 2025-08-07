using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.common;

namespace TaskManager.Infrastructure.repositories.project;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    private readonly TaskManagerDbContext _context;
    public ProjectRepository(TaskManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Project?> GetProjectWithTasksAsync(Guid id)
        => await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);
}