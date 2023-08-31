using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.DeleteOffer;

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, int>
{
    private readonly IGenericRepository<Offer, int> _genericRepository;
     
    
    public DeleteOfferCommandHandler(IGenericRepository<Offer,int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _genericRepository.GetById(request.Id);
        if (offer is null)
        {
            throw new NotFoundException($"{offer} doesn't exist");
        }

        await _genericRepository.Delete(offer);
        return offer.Id;
    }
}