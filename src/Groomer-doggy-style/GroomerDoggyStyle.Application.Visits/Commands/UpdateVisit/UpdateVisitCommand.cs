using GroomerDoggyStyle.Application.Visits.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.UpdateVisit;

public record UpdateVisitCommand(VisitDto VisitDto, int Id) : IRequest;