using Schola.Shared.Abstractions.Domains;

public sealed class SectionEntity : AggregateRoot<long>
{
    public SectionName Name { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public string CreatedBy { get; private set; } 
    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }

    // EF Core constructor
    private SectionEntity()
    {
    }

    public SectionEntity(SectionName name,string createdBy)
    {
        Name = name;
        CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
            ? createdBy
            : throw new ClassInvalidException("Created by is required.");

        CreatedDate = DateTime.UtcNow;

        AddEvent(new SectionCreatedEvent(Name, CreatedBy));
    }

    public void ChangeName(SectionName newName, string updatedBy)
    {
        if (Name == newName) return;

        Name = newName;
        SetUpdatedBy(updatedBy);

        AddEvent(new ClassNameChangedEvent(Id, newName));
    }


    public void UpdateSectionName(
        SectionName name,
        string updatedBy)
    {
        var hasChanged = false;

        if (Name != name)
        {
            Name = name;
            hasChanged = true;
        }

        if (!hasChanged) return;

        SetUpdatedBy(updatedBy);

        AddEvent(new SectionUpdatedEvent(Id, Name));
    }

    public void Delete()
    {
        AddEvent(new SectionDeletedEvent(Id));
    }


    private void SetUpdatedBy(string updatedBy)
    {
        UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
            ? updatedBy
            : throw new SectionInvalidException("Updated by is required.");

        UpdatedDate = DateTime.UtcNow;
    }
}