using GroomerDoggyStyle.Application.Offers.DTO;
using GroomerDoggyStyle.Application.Offers.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Offers.Query.GetAllOffers;

public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, IEnumerable<OfferDto>>
{
    private readonly IGenericRepository<Offer, int> _genericRepository;
    private static readonly OfferMapper _mapper = new();

    public GetAllOffersQueryHandler(IGenericRepository<Offer, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<OfferDto>> Handle(GetAllOffersQuery request, CancellationToken cancellationToken)
    {
        var offers = await _genericRepository.GetAll();
        return _mapper.MapOffersToOffersDto(offers);
    }
}