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

    [HttpPost]
    public async Task<IActionResult> AddClass([FromBody] CreateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    // [HttpPut]
    // public async Task<IActionResult> UpdateClass([FromBody] UpdateClassCommand command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok(true);
    // }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteClass([FromBody] DeleteClassCommand command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok(true);
    // }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<ClassEntityDto>>> GetClasses([FromQuery] GetClassById query)
    // {
    //     var result = await _queryDispatcher.QueryAsync(query);

    //     return Ok(result);
    // }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    // [HttpPost]
    // public async Task<IActionResult> AddSection([FromBody] CreateClassCommand command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok(true);
    // }

    // [HttpPut]
    // public async Task<IActionResult> UpdateSection([FromBody] UpdateClassCommand command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok(true);
    // }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteSection([FromBody] DeleteClassCommand command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok(true);
    // }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<ClassEntityDto>>> GetSections([FromQuery] GetClassById query)
    // {
    //     var result = await _queryDispatcher.QueryAsync(query);
        
    //     return Ok(result);
    // }



}