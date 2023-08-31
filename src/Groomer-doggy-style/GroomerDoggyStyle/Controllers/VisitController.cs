using GroomerDoggyStyle.Application.Visits.Commands.CreteVisit;
using GroomerDoggyStyle.Application.Visits.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;
[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] VisitDto visitDto)
    {
        var id = await _mediator.Send(new CreateVisitCommand(visitDto));

        return Created($"api/visits/{id}", null);
    }
}