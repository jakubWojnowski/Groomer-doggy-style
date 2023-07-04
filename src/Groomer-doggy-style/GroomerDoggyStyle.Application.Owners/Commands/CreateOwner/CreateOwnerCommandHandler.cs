
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using OwnerMapper = GroomerDoggyStyle.Application.Owners.Mappings.OwnerMapper;

namespace GroomerDoggyStyle.Application.Owners.Commands.CreateOwner;

public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly static OwnerMapper _mapper = new();

    public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }
    public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = _mapper.MapOwnerDtoToOwner(request.OwnerDto);

        var id = await _ownerRepository.CreateOwnerAsync(owner);

        return id;
    }
}
