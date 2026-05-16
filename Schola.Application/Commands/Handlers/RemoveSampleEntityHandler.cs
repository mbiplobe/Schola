// using Schola.Application.Exceptions;
// using Schola.Domain.Repositories;
// using Schola.Shared.Abstractions.Commands;

// namespace Schola.Application.Commands.Handlers;

// internal sealed class RemoveSampleEntityHandler : ICommandHandler<RemoveSampleEntity>
// {
//     private readonly ISampleEntityRepository _repository;

//     public RemoveSampleEntityHandler(ISampleEntityRepository repository)
//         => _repository = repository;

//     public async Task HandleAsync(RemoveSampleEntity command)
//     {
//         var sampleEntity = await _repository.GetAsync(command.Id);

//         if (sampleEntity is null)
//         {
//             throw new SampleEntityNotFound(command.Id);
//         }

//         await _repository.DeleteAsync(sampleEntity);
//     }
// }