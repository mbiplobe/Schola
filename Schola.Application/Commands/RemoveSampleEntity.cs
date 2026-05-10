using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands;

public record RemoveSampleEntity(Guid Id) : ICommand;
