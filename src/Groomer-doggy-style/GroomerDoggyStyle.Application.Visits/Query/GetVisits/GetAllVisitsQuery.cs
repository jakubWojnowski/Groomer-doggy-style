using GroomerDoggyStyle.Application.Visits.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Query.GetVisits;

public record GetAllVisitsQuery : IRequest<IEnumerable<VisitDto>>;
