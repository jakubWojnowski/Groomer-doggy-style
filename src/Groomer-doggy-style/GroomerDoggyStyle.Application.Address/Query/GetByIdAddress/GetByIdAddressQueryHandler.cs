using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Query.GetByIdAddress;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, AddressDto>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericRepository;
    private static readonly AddressMapper _mapper = new();

    public GetByIdAddressQueryHandler(IGenericRepository<Domain.Entities.Address, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<AddressDto> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var address = await _genericRepository.GetById(request.Id);
        if (address is null) throw new NotFoundException("Address not found");

        var addressDto = _mapper.MapAddressToAddressDto(address);
        return addressDto;
    }
}