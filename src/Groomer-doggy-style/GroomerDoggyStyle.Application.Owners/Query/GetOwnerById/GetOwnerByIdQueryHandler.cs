using GroomerDoggyStyle.Application.Owners.DTO;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using OwnerMapper = GroomerDoggyStyle.Application.Owners.Mappings.OwnerMapper;

namespace GroomerDoggyStyle.Application.Owners.Query.GetOwnerById;

public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerDto>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly static OwnerMapper _mapper = new();
    public GetOwnerByIdQueryHandler(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }
    public async Task<OwnerDto> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        var owner = await _ownerRepository.GetOwnerByIdAsync(request.Id);

        if (owner == null)
            throw new NotFoundException("Owner not found");

        var ownerDto = _mapper.MapOwnerToOwnerDto(owner);

        return ownerDto;
    }
}
