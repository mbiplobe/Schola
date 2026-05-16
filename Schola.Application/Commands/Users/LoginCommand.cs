using Schola.Shared.Abstractions.Commands;

public class LoginCommand : ICommand
{
    public string Identity { get; }
    public string Password { get; }

    public LoginCommand(string identity, string password)
    {
        Identity = identity;
        Password = password;
    }
}
