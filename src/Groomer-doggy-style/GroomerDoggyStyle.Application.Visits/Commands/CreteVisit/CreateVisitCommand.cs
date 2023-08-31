using GroomerDoggyStyle.Application.Visits.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.CreteVisit;

public record CreateVisitCommand(VisitDto VisitDto) : IRequest<int>;