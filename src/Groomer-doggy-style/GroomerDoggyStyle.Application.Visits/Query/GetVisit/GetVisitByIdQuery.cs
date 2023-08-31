using GroomerDoggyStyle.Application.Visits.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Query.GetVisit;

public record GetVisitByIdQuery(int Id) : IRequest<VisitDto>;