using Microsoft.AspNetCore.Mvc;
using Schola.Api.Controllers;
using Schola.Shared.Abstractions.Commands;
using Schola.Shared.Abstractions.Queries;

public class ClassController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ClassController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost("class")]
    public async Task<IActionResult> AddClass([FromBody] CreateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpPut("class")]
    public async Task<IActionResult> UpdateClass([FromBody] UpdateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpDelete("class")]
    public async Task<IActionResult> DeleteClass([FromBody] DeleteClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpGet("class")]
    public async Task<ActionResult<IEnumerable<ClassEntityDto>>> GetClasses([FromQuery] GetClasses query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

}