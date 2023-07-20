using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericAddressRepository;
    private readonly IGenericRepository<GroomerShop, int> _genericGroomerShopRepository;
    private static readonly AddressMapper _mapper = new();

    public CreateAddressCommandHandler(IGenericRepository<Domain.Entities.Address, int> genericAddressRepository, IGenericRepository<GroomerShop, int> genericGroomerShopRepository)
    {
        _genericAddressRepository = genericAddressRepository;
        _genericGroomerShopRepository = genericGroomerShopRepository;
    }
    public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = _mapper.MapAddressDtoToAddress(request.AddressDto);
        var groomerShop = await _genericGroomerShopRepository.GetById(request.AddressDto.GroomerShopId);
        if (groomerShop is null) throw new NotFoundException("groomerShop doesnt exist");
        var id = await _genericAddressRepository.Add(address);
        return id;
    }
}