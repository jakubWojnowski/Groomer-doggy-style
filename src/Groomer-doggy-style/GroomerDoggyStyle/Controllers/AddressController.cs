using GroomerDoggyStyle.Application.Address.Commands.CreateAddress;
using GroomerDoggyStyle.Application.Address.DTO;
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

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AddressDto addressDto)
    {
        var id = await _mediator.Send(new CreateAddressCommand(addressDto));

        return Created($"address/{id}", null);

    }
}