using Schola.Domain.Repositories;
using Schola.Shared.Abstractions.Commands;

class UserRegistrationHandler(IUserRepository _repository, IUserFactory _factory) : ICommandHandler<CreateUserCommand>
{

    public async Task HandleAsync(CreateUserCommand command)
    {

        var userEntity = _factory.Create(
            command.FirstName,
            command.MiddleName ?? string.Empty,
            command.LastName,
            command.Email,
            command.Mobile,
            command.Password
        );

        userEntity.

        await _repository.AddAsync(userEntity);
    }
}
