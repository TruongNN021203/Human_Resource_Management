namespace Shared.Kernel.Interfaces;

public interface IAuditable
{
    string CreatedBy { get; }
    string? UpdatedBy { get; }
    DateTimeOffset? UpdatedAt { get; }
}
