using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.DeleteOffer;

public record DeleteOfferCommand(int Id) : IRequest<int>;
