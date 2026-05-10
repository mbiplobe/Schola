using Schola.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;

    public string CreatedBy { get; protected set; } = string.Empty;

    public DateTime? UpdatedDate { get; protected set; }

    public string? UpdatedBy { get; protected set; }
}