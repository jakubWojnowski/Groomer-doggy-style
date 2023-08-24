using GroomerDoggyStyle.Application.Offers.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.UpdateOffer;

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand>
{
    private readonly IGenericRepository<Offer, int> _genericRepository;
    private static readonly OfferMapper _mapper = new();

    public UpdateOfferCommandHandler(IGenericRepository<Offer, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _genericRepository.GetById(request.Id);
        if (offer is null)
            throw new NotFoundException($"{offer} doesn't exist");
        var updatedOffer = _mapper.MapAndUpdateOffer(request.OfferDto, offer);
        await _genericRepository.Update(updatedOffer);
    }
}