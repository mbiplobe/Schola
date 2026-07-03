
using Schola.Shared.Abstractions.Commands;

public sealed record CreateSectionCommand(
    string Name,
    string? CreatedBy
) : ICommand;

public sealed record UpdateSectionCommand(
    long Id,
    string Name,
    string UpdatedBy
) : ICommand;

public sealed record DeleteSectionCommand(long Id) : ICommand;