using Microsoft.AspNetCore.Mvc;
using Schola.Api.Controllers;
using Schola.Shared.Abstractions.Commands;
using Schola.Shared.Abstractions.Queries;

public class AcademicSetupController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public AcademicSetupController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public async Task<IActionResult> Post([FromBody] CreateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }



}