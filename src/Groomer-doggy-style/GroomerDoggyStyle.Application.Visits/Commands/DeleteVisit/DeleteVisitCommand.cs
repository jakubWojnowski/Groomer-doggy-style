using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.DeleteVisit;

public record DeleteVisitCommand(int Id) : IRequest<int>;