using TaskManager.Domain.Common;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Events;

public class TaskCreatedEvent : DomainEvent
{
    public TaskItem Task { get; }

    public TaskCreatedEvent(TaskItem task)
    {
        Task = task;
        OccurredOn = DateTime.UtcNow;
    }
}