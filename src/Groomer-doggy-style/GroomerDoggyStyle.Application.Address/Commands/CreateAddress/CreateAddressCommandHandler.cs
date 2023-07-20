using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericRepository;
    private static readonly AddressMapper _mapper = new();

    public CreateAddressCommandHandler(IGenericRepository<Domain.Entities.Address, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = _mapper.MapAddressDtoToAddress(request.AddressDto);
        var id = await _genericRepository.Add(address);
        return id;
    }
}