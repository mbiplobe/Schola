namespace Schola.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; protected set; }

    public Guid Uuid { get; protected set; } = Guid.NewGuid();
}