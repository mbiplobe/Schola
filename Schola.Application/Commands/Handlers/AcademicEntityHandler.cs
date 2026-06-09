
using Schola.Shared.Abstractions.Commands;

internal sealed class AcademicCreateEntityHandler : ICommandHandler<CreateClassCommand>
{
    private readonly IClassRepository _repository;

    public AcademicCreateEntityHandler(IClassRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateClassCommand command)
    {
        var name = new ClassName(command.Name);
        var description = command.Description;

        var classEntity = new ClassEntity(
            name,
            description,
            command.CreatedBy
        );

        await _repository.AddAsync(classEntity);
    }

}

