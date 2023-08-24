using GroomerDoggyStyle.Application.Offers.Commands.CreateOffer;
using GroomerDoggyStyle.Application.Offers.Commands.DeleteOffer;
using GroomerDoggyStyle.Application.Offers.Commands.UpdateOffer;
using GroomerDoggyStyle.Application.Offers.DTO;
using GroomerDoggyStyle.Application.Offers.Query.GetAllOffers;
using GroomerDoggyStyle.Application.Offers.Query.GetOffer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;
[Route("api")]
[ApiController]
public class OfferController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfferController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("offer")]
    public async Task<ActionResult> Create([FromBody] OfferDto offerDto)
    {
        var id = await _mediator.Send(new CreateOfferCommand(offerDto));

        return Created($"api/offer/{id}", null);

    }
    [HttpGet("offer/{id}")]
    public async Task<ActionResult<OfferDto>> Get(int id)
    {
        var offer = await _mediator.Send(new GetOfferByIdQuery(id));
        return Ok(offer);
    }
    [HttpGet("offers")]
    public async Task<ActionResult<IEnumerable<OfferDto>>> GetAll()
    {
        var offers = await _mediator.Send(new GetAllOffersQuery());
        return Ok(offers);
    }
    [HttpPut("offer/{id}")]
    public async Task<ActionResult> Update([FromBody] OfferDto offerDto,[FromRoute] int id)
    {
        await _mediator.Send(new UpdateOfferCommand(id, offerDto));
        return NoContent();
    }

    [HttpDelete("offer/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteOfferCommand(id));
        return NoContent();
    }
}