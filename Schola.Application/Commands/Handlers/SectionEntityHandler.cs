// // using Schola.Domain.Repositories;
// using Schola.Shared.Abstractions.Commands;

// internal sealed class SectionAddEntityHandler : ICommandHandler<CreateSectionCommand>
// {
//      private readonly ISectionRepository _repository;

//     public SectionAddEntityHandler(ISectionRepository repository)
//         => _repository = repository;

//     public async Task HandleAsync(CreateSectionCommand command)
//     {
//         var name = new SectionName(command.Name);
//         var createdBy = command.CreatedBy;

//         var sectionEntity = new SectionEntity(
//             name,
//             createdBy
//         );

//         await _repository.AddAsync(sectionEntity);
//     }
// }

// internal sealed class SectionUpdateEntityHandler : ICommandHandler<UpdateSectionCommand>
// {
//     private readonly ISectionRepository _repository;

//     public SectionUpdateEntityHandler(ISectionRepository repository)
//         => _repository = repository;

//     public async Task HandleAsync(UpdateSectionCommand command)
//     {
//         var sectionEntity = await _repository.GetAsync(command.Id);

//         if (sectionEntity is null)
//         {
//             throw new SectionNotFoundException(command.Id);
//         }

//         sectionEntity.UpdateSectionName(command.Name, command.UpdatedBy);

//         await _repository.UpdateAsync(sectionEntity);
//     }
// }

// internal sealed class SectionDeleteEntityHandler : ICommandHandler<DeleteSectionCommand>
// {
//     private readonly ISectionRepository _repository;

//     public SectionDeleteEntityHandler(ISectionRepository repository)
//         => _repository = repository;

//     public async Task HandleAsync(DeleteSectionCommand command)
//     {
//         var sectionEntity = await _repository.GetAsync(command.Id);

//         if (sectionEntity is null)
//         {
//             throw new SectionNotFoundException(command.Id);
//         }

//         await _repository.DeleteAsync(sectionEntity);
//     }



// }


