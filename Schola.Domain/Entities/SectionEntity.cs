
using Schola.Shared.Abstractions.Domains;

public sealed class SectionEntity : AggregateRoot<long>
{
    public SectionName Name { get; private set; }

    public string Description { get; private set; }


    public DateTime? CreatedDate { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }
    // EF Core constructor
    private SectionEntity()
    {
    }

    public SectionEntity(
        long id,
        SectionName name,
        string description,
        string createdBy)
    {
        Id = id;
        Name = name;
        CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
            ? createdBy
            : throw new ClassInvalidException("Created by is required.");

        Description = !string.IsNullOrWhiteSpace(description)
            ? description
            : throw new ClassInvalidException("Description by is required.");

        CreatedDate = DateTime.UtcNow;

        AddEvent(new SectionAddedEvent(Id, Name, Description, CreatedBy));
    }

    

   

    public void UpdateSection(
        SectionName name,
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

        if (!hasChanged) return;

        SetUpdatedBy(updatedBy);

        AddEvent(new SectionUpdatedEvent(Id, Name: Name,description, UpdatedBy ?? string.Empty));
    }

    public void Delete()
    {
        AddEvent(new SectionDeletedEvent(Id));
    }


    private void SetUpdatedBy(string updatedBy)
    {
        UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
            ? updatedBy
            : throw new ClassInvalidException("Updated by is required.");

        UpdatedDate = DateTime.UtcNow;
    }
}