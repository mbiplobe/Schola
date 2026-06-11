
using Schola.Shared.Abstractions.Commands;
using Schola.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Schola.Api.Controllers;

public class UserProfileController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public UserProfileController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserEntityDto>> Get([FromRoute] GetUserEntity query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

   

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntityDto>>> Get([FromQuery] SearchUserEntity query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = command.Id ?? Guid.NewGuid();
        command = command with { Id = id };
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    // [HttpPut("{SampleEntityId}/items")]
    // public async Task<IActionResult> Put([FromBody] AddSampleEntityItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpPut("{SampleEntityId:guid}/items/{name}/Take")]
    // public async Task<IActionResult> Put([FromBody] TakeItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpDelete("{SampleEntityId:guid}/items/{name}")]
    // public async Task<IActionResult> Delete([FromBody] RemoveSampleEntityItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpDelete("{id:guid}")]
    // public async Task<IActionResult> Delete([FromBody] RemoveSampleEntity command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }
}
