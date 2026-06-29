using Schola.Shared.Abstractions.Commands;

public sealed record CreateClassCommand(
    string Name,
    string? Description,
    string? CreatedBy
) : ICommand;

public sealed record UpdateClassCommand(
    long Id,
    string Name,
    string? Description,
    string UpdatedBy
) : ICommand;

public sealed record DeleteClassCommand(long Id) : ICommand;

// public sealed record CreateSectionCommand(
//     string Name,
//     string CreatedBy
// ) : ICommand;

// public sealed record UpdateSectionCommand(
//     long Id,
//     SectionName Name,
//     string UpdatedBy
// ) : ICommand;

// public sealed record DeleteSectionCommand(long Id) : ICommand;