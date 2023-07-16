
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using OwnerMapper = GroomerDoggyStyle.Application.Owners.Mappings.OwnerMapper;

namespace GroomerDoggyStyle.Application.Owners.Commands.CreateOwner;

public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IGenericRepository<Owner, int> _genericRepository;
    private readonly static OwnerMapper _mapper = new();

    public CreateOwnerCommandHandler(IOwnerRepository ownerRepository, IGenericRepository<Owner, int> genericRepository)
    {
        _ownerRepository = ownerRepository;
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = _mapper.MapOwnerDtoToOwner(request.OwnerDto);
        var id = await _genericRepository.Add(owner);
        
        return id;
    }
}
