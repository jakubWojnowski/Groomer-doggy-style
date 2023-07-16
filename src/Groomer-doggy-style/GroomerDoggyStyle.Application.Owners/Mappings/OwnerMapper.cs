using GroomerDoggyStyle.Application.Owners.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Owners.Mappings;

[Mapper]
public partial class OwnerMapper
{
    public partial Owner MapOwnerDtoToOwner(OwnerDto ownerDto);
    public partial OwnerDto MapOwnerToOwnerDto(Owner owner);
    public partial IEnumerable<OwnerDto> MapOwnersToOwnersDto(IEnumerable<Owner> owners);
    
    public Owner MapAndUpdate(OwnerDto ownerDto, Owner owner)
    {
        owner.Name = ownerDto.Name;
        owner.LastName = ownerDto.LastName;
        owner.Mail = ownerDto.Mail;
        owner.PhoneNumber = ownerDto.PhoneNumber;

        return owner;
    }
}
