using GroomerDoggyStyle.Application.Address.Commands.CreateAddress;
using GroomerDoggyStyle.Application.Address.Commands.DeleteAddress;
using GroomerDoggyStyle.Application.Address.Commands.UpdateAddress;
using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Application.Address.Query.GetAllAddresses;
using GroomerDoggyStyle.Application.Address.Query.GetByIdAddress;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;
[Route("api")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("address")]
    public async Task<ActionResult> Create([FromBody] AddressDto addressDto)
    {
        var id = await _mediator.Send(new CreateAddressCommand(addressDto));

        return Created($"address/{id}", null);

    }
    [HttpPut("address/{id}")]
    public async Task<ActionResult> Update([FromBody] AddressDto addressDto, [FromRoute] int id)
    {
        await _mediator.Send(new UpdateAddressCommand(addressDto, id));
        return Ok();

    }
    
    [HttpGet("address/{id}")]
    public async Task<ActionResult> GetById( [FromRoute] int id)
    {
       var address = await _mediator.Send(new GetByIdAddressQuery(id));
        return Ok(address);

    }
    [HttpGet("address")]
    public async Task<ActionResult> GetAddresses()
    {
       var addresses = await _mediator.Send(new GetAllAddressesQuery());
        return Ok(addresses);

    } 
    [HttpDelete("address/{id}")]
    public async Task<ActionResult> Delete( [FromRoute] int id)
    {
        await _mediator.Send(new DeleteAddressCommand(id));
        return NoContent();

    }
}