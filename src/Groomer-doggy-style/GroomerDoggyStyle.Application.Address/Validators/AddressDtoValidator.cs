using FluentValidation;
using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;

namespace GroomerDoggyStyle.Application.Address.Validators;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator(IGenericRepository<GroomerShop, int> genericRepository)
    {
        /*RuleFor(a => a.GroomerShopId).Custom((value, context) =>
        {
            var groomerShop = genericRepository.GetById(value);
            if (groomerShop is null)
            {
                context.AddFailure($"{groomerShop.Id} is not in use");
            }
        });*/
    }
    
}