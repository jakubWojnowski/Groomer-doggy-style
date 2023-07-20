using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Address.Mappings;
[Mapper]
public partial class AddressMapper
{
    public partial Domain.Entities.Address MapAddressDtoToAddress(AddressDto addressDto);
    public partial AddressDto MapAddressToAddressDto(Domain.Entities.Address address);
    public partial IEnumerable<AddressDto> MapAddressesDtoToAddress(IEnumerable<Domain.Entities.Address> addresses);
    
    public Domain.Entities.Address MapAndUpdate(AddressDto addressDto, Domain.Entities.Address address)
    {
        address.Country = addressDto.Country;
        address.City = addressDto.City;
        address.Street = addressDto.Street;
        address.BuildingNumber = addressDto.BuildingNumber;
        address.PostalCode = addressDto.PostalCode;

        return address;
    }
}