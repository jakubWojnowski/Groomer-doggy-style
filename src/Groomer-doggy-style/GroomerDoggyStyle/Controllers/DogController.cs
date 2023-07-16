using GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;
using GroomerDoggyStyle.Application.Dogs.Commands.DeleteDog;
using GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;
using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Query.GetAllDogs;
using GroomerDoggyStyle.Application.Dogs.Query.GetDogById;
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

    [HttpGet("GetAllDogs")]

    public async Task<ActionResult<IEnumerable<DogDto>>> GetDogs()
    {
        var dogs = await _mediator.Send(new GetAllDogsQuery());
        return Ok(dogs);
    }
    
    [HttpGet("GetDogById/{dogId}")]

    public async Task<ActionResult<DogDto>> GetDog([FromRoute] int dogId)
    {
        var dog = await _mediator.Send(new GetDogByIdQuery(dogId));
        return Ok(dog);
    }
    [HttpDelete("DeleteDog/{dogId}")]

    public async Task<ActionResult<DogDto>> DeleteDog([FromRoute] int dogId)
    {
         await _mediator.Send(new DeleteDogCommand(dogId));
         return NoContent();
    }
        
}
