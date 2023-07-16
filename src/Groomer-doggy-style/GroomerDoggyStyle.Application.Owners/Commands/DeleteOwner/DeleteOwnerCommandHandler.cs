using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Commands.DeleteOwner;

public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IGenericRepository<Owner, int> _genericRepository;

    public DeleteOwnerCommandHandler(IOwnerRepository ownerRepository, IGenericRepository<Owner, int> genericRepository)
    {
        _ownerRepository = ownerRepository;
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = await _genericRepository.GetById(request.Id);

        if (owner == null)
            throw new NotFoundException("Owner not found");

        await _genericRepository.Delete(owner);
    }
}
