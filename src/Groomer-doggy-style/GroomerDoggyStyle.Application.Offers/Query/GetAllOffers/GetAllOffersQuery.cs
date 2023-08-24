using GroomerDoggyStyle.Application.Offers.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Query.GetAllOffers;

public record GetAllOffersQuery() : IRequest<IEnumerable<OfferDto>>;
