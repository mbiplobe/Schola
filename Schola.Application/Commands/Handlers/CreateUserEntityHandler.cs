using Schola.Domain.Repositories;
using Schola.Shared.Abstractions.Commands;

namespace Schola.Application.Commands.Handlers;

internal sealed class CreateUserEntityHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;

    public CreateUserEntityHandler(IUserRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateUserCommand command)
    {

        var Id = EntityID.NewId();

        var fullName = new FullName(command.FirstName, command.MiddleName, command.LastName);
        var email = new Email(command.Email);
        var mobile = new Mobile(command.Mobile);
        var password = new Password(command.Password);

        var user = new UserEntity(
            Id,
            fullName,
            email,
            mobile,
            password
        );
        await _repository.AddAsync(user);
    }

}

