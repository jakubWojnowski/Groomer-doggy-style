using GroomerDoggyStyle.Application.Offers.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Query.GetOffer;

public record GetOfferByIdQuery(int Id) : IRequest<OfferDto>;
