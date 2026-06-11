using Schola.Shared.Abstractions.Domains;

public sealed record ClassCreatedEvent(
    string Name,
    string? Description,
    string CreatedBy
) : IDomainEvent;

public sealed record ClassUpdatedEvent(
    long ClassId,
    string Name,
    string? Description
) : IDomainEvent;

public sealed record ClassNameChangedEvent(
    long ClassId,
    string Name
) : IDomainEvent;

public sealed record ClassDescriptionChangedEvent(
    long ClassId,
    string? Description
) : IDomainEvent;

public sealed record ClassDeletedEvent(
    long ClassId
) : IDomainEvent;

//////////////////////////////////////
public sealed record SectionCreatedEvent(
    SectionName Name,
    string CreatedBy
) : IDomainEvent;

public sealed record SectionUpdatedEvent(
    long SectionId,
    SectionName Name
) : IDomainEvent;

public sealed record SectionDeletedEvent(
    long SectionId
) : IDomainEvent;