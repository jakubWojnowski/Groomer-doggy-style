using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Commands.DeleteOwner;

public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
{
    private readonly IOwnerRepository _ownerRepository;

    public DeleteOwnerCommandHandler(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }
    public async Task Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = await _ownerRepository.GetOwnerByIdAsync(request.Id);

        if (owner == null)
            throw new NotFoundException("Owner not found");

        await _ownerRepository.DeleteOwnerAsync(owner);
    }
}
