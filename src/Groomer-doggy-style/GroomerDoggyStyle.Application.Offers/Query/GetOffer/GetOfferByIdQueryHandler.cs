using GroomerDoggyStyle.Application.Offers.DTO;
using GroomerDoggyStyle.Application.Offers.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Query.GetOffer;

public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, OfferDto>
{
    private readonly IGenericRepository<Offer, int> _genericRepository;
    private static readonly OfferMapper _mapper = new();

    public GetOfferByIdQueryHandler(IGenericRepository<Offer, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<OfferDto> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
    {
        var offer = await _genericRepository.GetById(request.Id);
        if (offer is null)
            throw new NotFoundException($"{offer} doesn't exist");
        return _mapper.MapOfferToOfferDto(offer);
        
    }
}