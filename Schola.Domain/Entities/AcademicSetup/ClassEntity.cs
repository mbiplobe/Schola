using Schola.Shared.Abstractions.Domains;

public sealed class ClassEntity : AggregateRoot<long>
{
    
    public ClassName Name { get; private set; }
    public string? Description { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public string CreatedBy { get; private set; } 
    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }

    // EF Core constructor
    private ClassEntity()
    {
    }

    public ClassEntity(
        long id,
        ClassName name,
        string? description,
        string createdBy)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
            ? createdBy
            : throw new ClassInvalidException("Created by is required.");

        CreatedDate = DateTime.UtcNow;

        AddEvent(new ClassCreatedEvent(Name, Description, CreatedBy));
    }

    public void ChangeName(ClassName newName, string updatedBy)
    {
        if (Name == newName) return;

        Name = newName;
        SetUpdatedBy(updatedBy);
        

        AddEvent(new ClassNameChangedEvent(Id, newName));
    }

    public void ChangeDescription(string? newDescription, string updatedBy)
    {
        if (Description == newDescription) return;

        Description = newDescription;
        SetUpdatedBy(updatedBy);

        AddEvent(new ClassDescriptionChangedEvent(Id, newDescription));
    }

    public void UpdateProfile(
        ClassName name,
        string? description,
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

        AddEvent(new ClassUpdatedEvent(Id, Name, Description));
    }

    public void Delete()
    {
        AddEvent(new ClassDeletedEvent(Id));
    }


    private void SetUpdatedBy(string updatedBy)
    {
        UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
            ? updatedBy
            : throw new ClassInvalidException("Updated by is required.");

        UpdatedDate = DateTime.UtcNow;
    }
}