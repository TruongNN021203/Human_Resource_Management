using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Kernel.Common;

public abstract class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; protected set; }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Ulid PublicId { get; protected set; }

    public DateTimeOffset CreatedAt { get; protected set; }

    protected Entity()
    {
        Id = IdGenerator.NewId();
        PublicId = Ulid.NewUlid();
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
