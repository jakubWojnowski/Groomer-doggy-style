using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Mappings;

[Mapper]
public partial class OwnerMapper
{
    public partial Owner MapOwnerDtoToOwner(OwnerDto ownerDto);
    public partial OwnerDto MapOwnerToOwnerDto(Owner owner);
    public partial IEnumerable<OwnerDto> MapOwnersToOwnersDto(IEnumerable<Owner> owners);
}
