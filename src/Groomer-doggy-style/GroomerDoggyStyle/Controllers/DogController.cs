using GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;
using GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;
using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controller;

[Route("api/dogs")]
[ApiController]
public class DogController : ControllerBase
{
    private readonly IMediator _mediator;

    public DogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("CreateDog/{ownerId}")]
    public async Task<ActionResult> Create([FromBody] DogDto dogDto, [FromRoute] int ownerId)
    {
        var id = await _mediator.Send(new CreateDogCommand(dogDto, ownerId));

        return Created($"api/dogs/{id}", null);
    }

    [HttpPut("UpdateDog/{dogId}")]
    public async Task<ActionResult> Update([FromBody] DogDto dogDto, [FromRoute] int dogId)
    {
        await _mediator.Send(new UpdateDogCommand(dogId, dogDto));
        return Ok();
    }
}
