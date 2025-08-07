using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Common;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Events;

namespace TaskManager.Infrastructure;

public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Ignore<DomainEvent>();
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.Ignore<TaskCompletedEvent>();
        modelBuilder.Ignore<TaskCreatedEvent>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Handle domain events dispatch here if needed
        return await base.SaveChangesAsync(cancellationToken);
    }
}