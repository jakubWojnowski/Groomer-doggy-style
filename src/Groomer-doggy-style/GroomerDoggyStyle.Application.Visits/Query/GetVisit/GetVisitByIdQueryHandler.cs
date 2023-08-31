using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Application.Visits.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Query.GetVisit;

public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, VisitDto>
{
    private readonly IGenericRepository<Visit, int> _genericRepository;
    private static readonly VisitMapper _mapper = new();

    public GetVisitByIdQueryHandler(IGenericRepository<Visit, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<VisitDto> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
    {
        var visit = await _genericRepository.GetById(request.Id);
        if (visit is null) throw new NotFoundException("Visit doesn't exist");
        var visitDto = _mapper.MapVisitToVisitDto(visit);
        return visitDto;
        
    }
}