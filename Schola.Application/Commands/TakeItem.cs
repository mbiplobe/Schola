using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands;

public record TakeItem(Guid sampleEntityId, string Name) : ICommand;