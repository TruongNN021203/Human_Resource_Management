namespace Contracts.Common;

public abstract record IntegrationEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTimeOffset OccurredAt { get; init; } = DateTimeOffset.UtcNow;
    public string EventName => GetType().Name;
    // version để backward compatibility
    public int Version { get; init; } = 1;
}
