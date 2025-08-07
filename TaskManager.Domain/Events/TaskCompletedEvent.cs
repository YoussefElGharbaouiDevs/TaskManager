using TaskManager.Domain.Common;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Events;

public class TaskCompletedEvent : DomainEvent
{
    public TaskItem Task { get; }

    public TaskCompletedEvent(TaskItem task)
    {
        Task = task;
        OccurredOn = DateTime.UtcNow;
    }
}