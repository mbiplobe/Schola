using Schola.Application.Exceptions;
using Schola.Application.Services;
using Schola.Domain.Factories;
using Schola.Domain.Repositories;
using Schola.Domain.ValueObjects;
using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands.Handlers;

public class CreateSampleEntityWithItemHandler : ICommandHandler<CreateSampleEntityWithItems>
{
    private readonly ISampleEntityRepository _repository;
    private readonly ISampleEntityFactory _factory;
    private readonly ISampleEntityReadService _readService;



    public CreateSampleEntityWithItemHandler(ISampleEntityRepository repository, ISampleEntityFactory factory,
        ISampleEntityReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task HandleAsync(CreateSampleEntityWithItems command)
    {
        var (id, name, gender, DestinationWriteModel) = command;


        if (await _readService.ExistsByNameAsync(name))
        {
            throw new SampleEntityAlreadyExistsException(name);
        }


        var destination = new SampleEntityDestination(DestinationWriteModel.City, DestinationWriteModel.Country);

        var sampleEntity = _factory.CreateWithDefaultItems(id, name, gender,
            destination);

        await _repository.AddAsync(sampleEntity);
    }

}

