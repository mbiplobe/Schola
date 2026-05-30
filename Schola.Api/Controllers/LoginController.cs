using Microsoft.AspNetCore.Mvc;
using Schola.Api.Controllers;
using Schola.Shared.Abstractions.Commands;
using Schola.Shared.Abstractions.Queries;

public class LoginController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : BaseController
{
    // [HttpPost]
    // public async Task<IActionResult> Login(LoginCommand command)
    // {
    //     //var result = await commandDispatcher.DispatchAsync(command);
    //     return OkOrNotFound(result);
    // }

    // [HttpPost]
    // public async Task<IActionResult> Login(LoginCommand command)
    // {
    //     // var result = await commandDispatcher.DispatchAsync(command);
    //     return OkOrNotFound(null);
    // }
}