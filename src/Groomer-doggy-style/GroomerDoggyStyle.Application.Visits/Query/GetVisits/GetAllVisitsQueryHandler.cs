using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Application.Visits.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Query.GetVisits;

public class GetAllVisitsQueryHandler : IRequestHandler<GetAllVisitsQuery, IEnumerable<VisitDto>>
{
    private readonly IGenericRepository<Visit, int> _genericRepository;
    private static VisitMapper _mapper = new();

    public GetAllVisitsQueryHandler(IGenericRepository<Visit, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<VisitDto>> Handle(GetAllVisitsQuery request, CancellationToken cancellationToken)
    {
       var visits = await _genericRepository.GetAll();
         return _mapper.MapVisitsToVisitsDto(visits);
    }
}