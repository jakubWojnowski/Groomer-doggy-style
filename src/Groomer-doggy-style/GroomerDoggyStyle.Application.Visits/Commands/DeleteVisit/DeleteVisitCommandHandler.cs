using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.DeleteVisit;

public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, int>
{
    private readonly IGenericRepository<Visit, int> _genericRepository;

    public DeleteVisitCommandHandler(IGenericRepository<Visit, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _genericRepository.GetById(request.Id);
        if (visit is null) throw new NotFoundException("Visit doesn't exist");
        await _genericRepository.Delete(visit);
        return visit.Id;
    }
}