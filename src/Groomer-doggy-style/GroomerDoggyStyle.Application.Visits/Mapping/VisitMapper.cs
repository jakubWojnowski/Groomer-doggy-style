using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Visits.Mapping;
[Mapper]
public partial class  VisitMapper
{
    
    public partial Visit MapVisitDtoToVisit(VisitDto visitDto);
    public partial VisitDto MapVisitToVisitDto(Visit visit);
    public partial IEnumerable<VisitDto> MapVisitsToVisitsDto(IEnumerable<Visit> visits);
    public Visit MapAndUpdateVisit(VisitDto visitDto, Visit visit)
    {
        visit.DateOfVisit = visitDto.DateOfVisit;
        visit.DurationInMinutes = visitDto.DurationInMinutes;
        visit.Price = visitDto.Price;
        visit.GroomerShopId = visitDto.GroomerShopId;
        visit.DogId = visitDto.DogId;

        return visit;
    }
}