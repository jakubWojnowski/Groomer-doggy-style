using GroomerDoggyStyle.Application.GroomerShops.Commands.CreateGroomerShops;
using GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopDelete;
using GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopUpdate;
using GroomerDoggyStyle.Application.GroomerShops.DTO;
using GroomerDoggyStyle.Application.GroomerShops.Query.GetAllGroomerShops;
using GroomerDoggyStyle.Application.GroomerShops.Query.GroomerShopGetById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;
[Route("api")]
[ApiController]
public class GroomerShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroomerShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("groomerShop")]
    public async Task<ActionResult<IEnumerable<GroomerShopDto>>> GetAllGroomerShops()
    {
        var groomerShops = await _mediator.Send(new GetAllGroomerShopsQuery());
        return Ok(groomerShops);
    }
    [HttpGet("groomerShop/{groomerShopId}")]
    public async Task<ActionResult<GroomerShopDto>> GetGroomerShopById(int groomerShopId)
    {
        var groomerShop = await _mediator.Send(new GetByIdGroomerShopQuery(groomerShopId));
        return Ok(groomerShop);
    }
    
    [HttpPost("groomerShop")]
    public async Task<ActionResult<GroomerShopDto>> CreateGroomerShop([FromBody] GroomerShopDto groomerShopDto)
    {
        var id = await _mediator.Send(new CreateGroomerShopCommand(groomerShopDto));
        return Created($"api/groomerShops/{id}", null);
    }
    [HttpPut("groomerShop/{groomerShopId}")]
    public async Task<ActionResult<GroomerShopDto>> CreateGroomerShop([FromRoute] int groomerShopId, [FromBody] GroomerShopDto groomerShopDto)
    {
         await _mediator.Send(new UpdateGroomerShopCommand(groomerShopDto, groomerShopId));
        return Ok();
    }
    
    [HttpDelete("groomerShop/{groomerShopId}")]
    public async Task<ActionResult<GroomerShopDto>> DeleteGroomerShop([FromRoute] int groomerShopId)
    {
        await _mediator.Send(new DeleteGroomerShopCommand( groomerShopId));
        return NoContent();
    }
}