using GroomerDoggyStyle.Application.Owners.Commands.CreateOwner;
using GroomerDoggyStyle.Application.Owners.Commands.DeleteOwner;
using GroomerDoggyStyle.Application.Owners.Commands.UpdateOwner;
using GroomerDoggyStyle.Application.Owners.DTO;
using GroomerDoggyStyle.Application.Owners.Query.GetAllOwners;
using GroomerDoggyStyle.Application.Owners.Query.GetOwnerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;

[Route("api/owners")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IMediator _mediator;

    public OwnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAll()
    {
        var owners = await _mediator.Send(new GetAllOwnersQuery());

        return Ok(owners);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> Get([FromRoute] int id)
    {
        var owner = await _mediator.Send(new GetOwnerByIdQuery(id));

        return Ok(owner);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] OwnerDto ownerDto)
    {
        var id = await _mediator.Send(new CreateOwnerCommand(ownerDto));

        return Created($"api/owners/{id}", null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] OwnerDto ownerDto)
    {
        //command.Id = id;
        await _mediator.Send(new UpdateOwnerCommand(id, ownerDto));

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteOwnerCommand(id));

        return NoContent();
    }


}
