using GroomerDoggyStyle.Application.Offers.DTO;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Offers.Mapping;
[Mapper]
public partial class OfferMapper
{
    
    //OfferDto
    public partial Domain.Entities.Offer MapOfferDtoToOffer(OfferDto offerDto);
    public partial OfferDto MapOfferToOfferDto(Domain.Entities.Offer offer);
    public partial IEnumerable<OfferDto> MapOffersToOffersDto(IEnumerable<Domain.Entities.Offer> offers);

    public Domain.Entities.Offer MapAndUpdateOffer(OfferDto offerDto, Domain.Entities.Offer offer)
    {
        offer.Name = offerDto.Name;
        offer.DurationTimeInMinutes = offerDto.DurationTimeInMinutes;
        offer.BasePrice = offerDto.BasePrice;

        return offer;
    }
}