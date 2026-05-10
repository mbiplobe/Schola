using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands;

public record RemoveSampleEntityItem(Guid sampleEntityId, string Name) : ICommand;
