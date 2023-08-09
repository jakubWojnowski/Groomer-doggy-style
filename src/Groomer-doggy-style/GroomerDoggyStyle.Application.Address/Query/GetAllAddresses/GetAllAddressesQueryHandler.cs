using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Query.GetAllAddresses;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDto>>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericRepository;
    private static readonly AddressMapper _mapper = new();

    public GetAllAddressesQueryHandler(IGenericRepository<Domain.Entities.Address, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var address = await _genericRepository.GetAll();

        return _mapper.MapAddressesDtoToAddress(address);
    }
}