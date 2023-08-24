using GroomerDoggyStyle.Application.Offers.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.UpdateOffer;

public record UpdateOfferCommand(int Id, OfferDto OfferDto) : IRequest;
