using GroomerDoggyStyle.Application.Offers.DTO;
using GroomerDoggyStyle.Domain.Entities;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.CreateOffer;

public record CreateOfferCommand(OfferDto OfferDto) : IRequest<int>;
