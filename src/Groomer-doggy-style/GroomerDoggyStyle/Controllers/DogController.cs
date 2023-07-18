using GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;
using GroomerDoggyStyle.Application.Dogs.Commands.DeleteDog;
using GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;
using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Query.GetAllDogs;
using GroomerDoggyStyle.Application.Dogs.Query.GetDogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;

[Route("api")]
[ApiController]
public class DogController : ControllerBase
{
    private readonly IMediator _mediator;

    public DogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("{ownerId}/dogs")]
    public async Task<ActionResult> Create([FromBody] DogDto dogDto, [FromRoute] int ownerId)
    {
        var id = await _mediator.Send(new CreateDogCommand(dogDto, ownerId));

        return Created($"api/dogs/{id}", null);
    }

    [HttpPut("dogs/{dogId}")]
    public async Task<ActionResult> Update([FromBody] DogDto dogDto, [FromRoute] int dogId)
    {
        await _mediator.Send(new UpdateDogCommand(dogId, dogDto));
        return Ok();
    }

    [HttpGet("dogs")]

    public async Task<ActionResult<IEnumerable<DogDto>>> GetDogs()
    {
        var dogs = await _mediator.Send(new GetAllDogsQuery());
        return Ok(dogs);
    }
    
    [HttpGet("dogs/{dogId}")]

    public async Task<ActionResult<DogDto>> GetDog([FromRoute] int dogId)
    {
        var dog = await _mediator.Send(new GetDogByIdQuery(dogId));
        return Ok(dog);
    }
    [HttpDelete("dogs/{dogId}")]

    public async Task<ActionResult<DogDto>> DeleteDog([FromRoute] int dogId)
    {
         await _mediator.Send(new DeleteDogCommand(dogId));
         return NoContent();
    }
        
}
