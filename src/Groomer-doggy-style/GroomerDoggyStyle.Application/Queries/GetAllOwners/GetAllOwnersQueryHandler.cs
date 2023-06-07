using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Queries.GetAllOwners
{
    public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, IEnumerable<OwnerDto>>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly OwnerMapper _mapper;
        public GetAllOwnersQueryHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = new();
        }
        public async Task<IEnumerable<OwnerDto>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _ownerRepository.GetAllOwnersAsync();

            var ownersDto = _mapper.MapOwnersToOwnersDto(owners);

            return ownersDto;
        }
    }
}
