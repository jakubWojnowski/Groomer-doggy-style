
using GroomerDoggyStyle.Application.Owners.DTO;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using OwnerMapper = GroomerDoggyStyle.Application.Owners.Mappings.OwnerMapper;

namespace GroomerDoggyStyle.Application.Owners.Commands.UpdateOwner;

public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IGenericRepository<Owner, int> _genericRepository;
    private readonly static OwnerMapper _mapper = new();
    public UpdateOwnerCommandHandler(IOwnerRepository ownerRepository, IGenericRepository<Owner, int> genericRepository)
    {
        _ownerRepository = ownerRepository;
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = await _genericRepository.GetById(request.Id);
        if (owner == null)
            throw new NotFoundException("Owner not found");
        var ownerUpdate = _mapper.MapAndUpdate(request.OwnerDto, owner);
        
        await _genericRepository.Update(ownerUpdate);
    }
}
