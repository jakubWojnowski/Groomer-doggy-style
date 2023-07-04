using GroomerDoggyStyle.Application.Owners.DTO;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using OwnerMapper = GroomerDoggyStyle.Application.Owners.Mappings.OwnerMapper;

namespace GroomerDoggyStyle.Application.Owners.Query.GetAllOwners;

public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, IEnumerable<OwnerDto>>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly static OwnerMapper _mapper = new();
    public GetAllOwnersQueryHandler(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }
    public async Task<IEnumerable<OwnerDto>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
    {
        var owners = await _ownerRepository.GetAllOwnersAsync();

        return _mapper.MapOwnersToOwnersDto(owners); ;
    }
}
