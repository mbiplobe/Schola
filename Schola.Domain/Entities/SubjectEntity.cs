using Schola.Shared.Abstractions.Domains;

public sealed class SubjectEntity : AggregateRoot<long>
{
    public SubjectName Name { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public string CreatedBy { get; private set; }

    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }

    // EF Core constructor
    private SubjectEntity()
    {
    }

    public SubjectEntity(
        long id,
        SubjectName name,
        string description,
        string createdBy)
    {
        Id = id;
        Name = name;

        CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
            ? createdBy
            : throw new SubjectInvalidException("Created by is required.");

        Description = !string.IsNullOrWhiteSpace(description)
            ? description
            : throw new SubjectInvalidException("Description is required.");

        CreatedDate = DateTime.UtcNow;

        AddEvent(new SubjectAddedEvent(
            Id,
            Name,
            Description,
            CreatedBy));
    }

    public void UpdateSubject(
        SubjectName name,
        string description,
        string updatedBy)
    {
        var hasChanged = false;

        if (Name != name)
        {
            Name = name;
            hasChanged = true;
        }

        if (Description != description)
        {
            Description = description;
            hasChanged = true;
        }

        if (!hasChanged)
        {
            return;
        }

        SetUpdatedBy(updatedBy);

        AddEvent(new SubjectUpdatedEvent(
            Id,
            Name,
            Description,
            UpdatedBy ?? string.Empty));
    }

    public void Delete()
    {
        AddEvent(new SubjectDeletedEvent(Id));
    }

    private void SetUpdatedBy(string updatedBy)
    {
        UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
            ? updatedBy
            : throw new SubjectInvalidException("Updated by is required.");

        UpdatedDate = DateTime.UtcNow;
    }
}
