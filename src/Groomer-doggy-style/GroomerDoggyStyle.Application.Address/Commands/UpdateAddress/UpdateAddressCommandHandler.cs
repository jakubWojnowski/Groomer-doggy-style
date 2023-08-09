using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericRepository;
    private static readonly AddressMapper _mapper = new();

    public UpdateAddressCommandHandler(IGenericRepository<Domain.Entities.Address, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _genericRepository.GetById(request.Id);
        if (address is null) throw new NotFoundException("Address not found");

        var addressUpdate = _mapper.MapAndUpdate(request.AddressDto, address);

        await _genericRepository.Update(addressUpdate);
    }
}