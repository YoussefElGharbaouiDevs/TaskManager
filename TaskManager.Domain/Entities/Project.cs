using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; private set; }

    // Navigation
    private readonly List<TaskItem> _tasks = new();
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    protected Project() { }

    public Project(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
}