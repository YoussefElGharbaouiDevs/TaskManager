using TaskManager.Domain.Common;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Events;

namespace TaskManager.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Priority Priority { get; private set; }
    public Status Status { get; private set; }
    public Guid ProjectId { get; private set; }

    // Navigation
    public Project Project { get; private set; }
    

    protected TaskItem() { }

    public TaskItem(string title, string? description, Priority priority, Guid projectId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;
        Status = Status.ToDo;
        ProjectId = projectId;

        AddDomainEvent(new TaskCreatedEvent(this));
    }

    public void UpdateStatus(Status newStatus)
    {
        if (Status != newStatus)
        {
            Status = newStatus;

            if (newStatus == Status.Done)
            {
                AddDomainEvent(new TaskCompletedEvent(this));
            }
        }
    }
}
