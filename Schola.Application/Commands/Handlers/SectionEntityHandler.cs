using Schola.Shared.Abstractions.Commands;

internal sealed class SectionAddEntityHandler : ICommandHandler<CreateSectionCommand>
{
    private readonly ICRUDRepository<SectionEntity, long> _repository;

    public SectionAddEntityHandler(ICRUDRepository<SectionEntity, long> repository)
        => _repository = repository;

    public async Task HandleAsync(CreateSectionCommand command)
    {
        var name = new SectionName(command.Name);
        var createdBy = command.CreatedBy;

        var sectionEntity = new SectionEntity(
            name,
            createdBy
        );

        await _repository.AddAsync(sectionEntity);
    }
}

internal sealed class SectionUpdateEntityHandler : ICommandHandler<UpdateSectionCommand>
{
    private readonly ICRUDRepository<SectionEntity, long> _repository;

    public SectionUpdateEntityHandler(ICRUDRepository<SectionEntity, long> repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateSectionCommand command)
    {
        var sectionEntity = await _repository.GetAsync(command.Id);

        if (sectionEntity is null)
        {
            throw new SectionNotFoundException(command.Id);
        }

        sectionEntity.UpdateSectionName(command.Name, command.UpdatedBy);

        await _repository.UpdateAsync(sectionEntity);
    }
}

internal sealed class SectionDeleteEntityHandler : ICommandHandler<DeleteSectionCommand>
{
    private readonly ICRUDRepository<SectionEntity, long> _repository;

    public SectionDeleteEntityHandler(ICRUDRepository<SectionEntity, long> repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteSectionCommand command)
    {
        var sectionEntity = await _repository.GetAsync(command.Id);

        if (sectionEntity is null)
        {
            throw new SectionNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(sectionEntity);
    }



}


