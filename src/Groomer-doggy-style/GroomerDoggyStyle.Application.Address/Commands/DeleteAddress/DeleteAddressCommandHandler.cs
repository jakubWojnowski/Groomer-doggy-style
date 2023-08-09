using GroomerDoggyStyle.Application.Address.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.DeleteAddress;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IGenericRepository<Domain.Entities.Address, int> _genericRepository;
    private static readonly AddressMapper _mapper = new();

    public DeleteAddressCommandHandler(IGenericRepository<Domain.Entities.Address, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _genericRepository.GetById(request.Id);
        if (address == null) throw new NotFoundException("Address is not found!");
        
        await _genericRepository.Delete(address);
    }
}