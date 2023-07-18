using GroomerDoggyStyle.Application.GroomerShops.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.GroomerShops.Mappings;
[Mapper]
public partial class GroomerShopMapper 
{
    public partial GroomerShop MapGroomerShopDtoToGroomerShop(GroomerShopDto groomerShopDto);
    public partial GroomerShopDto MapGroomerShopToGroomerShopDto(GroomerShop groomerShop);
    public partial IEnumerable<GroomerShopDto> MapGroomerShopsToGroomerShop(IEnumerable<GroomerShop> groomerShops);
    
    public GroomerShop MapAndUpdate(GroomerShopDto groomerShopDto, GroomerShop groomerShop)
    {
        groomerShop.Name = groomerShopDto.Name;
        groomerShop.Mail = groomerShopDto.Mail;
        groomerShop.PhoneNumber = groomerShopDto.PhoneNumber;

        return groomerShop;
    }
}