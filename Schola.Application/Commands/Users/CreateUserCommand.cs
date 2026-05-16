using Schola.Shared.Abstractions.Commands;

public record CreateUserCommand(Guid EntityId,
string FirstName,
string? MiddleName,
string LastName,
string Email,
string Mobile,
string Password) : ICommand;
