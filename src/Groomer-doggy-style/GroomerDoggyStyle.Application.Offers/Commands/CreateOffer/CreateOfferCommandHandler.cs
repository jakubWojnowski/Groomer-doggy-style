using GroomerDoggyStyle.Application.Offers.DTO;
using GroomerDoggyStyle.Application.Offers.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Commands.CreateOffer;

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
{
    private readonly IGenericRepository<Offer, int> _genericRepository;
    private static readonly OfferMapper _mapper = new();

    public CreateOfferCommandHandler(IGenericRepository<Offer, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = _mapper.MapOfferDtoToOffer(request.OfferDto);
        var id = await _genericRepository.Add(offer);
        return id;

    }
}