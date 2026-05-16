// using Schola.Domain.Repositories;
// using Schola.Shared.Abstractions.Commands;

// public class LoginCommandHandler(IUserRepository repository) : ICommandHandler<LoginCommand,LoginResponseDto>
// {
//     public async Task<LoginResponseDto> HandleAsync(LoginCommand command)
//     {
//         var user = await repository.GetUserIdAsync(command.Identity);
//         if (user == null || !user.ValidatePassword(command.Password))
//         {
//             throw new UnauthorizedAccessException("Invalid email or password.");
//         }

//         // Generate JWT token or any other login logic
//         return new LoginResponseDto
//         {
//             AccessToken = "generated-jwt-token",
//             RefreshToken = "generated-refresh-token"
//         };
//     }

// }
