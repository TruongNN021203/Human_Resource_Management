using Shared.Kernel.Interfaces;

namespace Shared.Kernel.Common;

public abstract class AuditableEntity : Entity, IAuditable
{
    public string CreatedBy { get; protected set; } = string.Empty;
    public string? UpdatedBy { get; protected set; }
    public DateTimeOffset? UpdatedAt { get; protected set; }

    public void SetUpdated(string updatedBy)
    {
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
