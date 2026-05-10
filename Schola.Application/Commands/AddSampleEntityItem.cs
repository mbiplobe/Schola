using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands.Handlers;

public record AddSampleEntityItem(Guid sampleEntityId, string Name, uint Quantity) : ICommand;
