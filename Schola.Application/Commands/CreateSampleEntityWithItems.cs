using Schola.Domain.Consts;
using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands;

public record CreateSampleEntityWithItems(Guid Id, string Name, Gender Gender,
   DestinationWriteModel Destionation) : ICommand;

public record DestinationWriteModel(string City, string Country);
