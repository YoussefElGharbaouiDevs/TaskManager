using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Common;

public class BaseEntity : IHasDomainEvent
{
    public Guid Id { get; protected set; }
    public List<DomainEvent> DomainEvents { get; } = new ();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => DomainEvents.Clear();
}