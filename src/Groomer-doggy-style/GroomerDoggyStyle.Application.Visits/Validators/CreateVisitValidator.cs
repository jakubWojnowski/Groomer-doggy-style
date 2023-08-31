using FluentValidation;
using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;

namespace GroomerDoggyStyle.Application.Visits.Validators;

public class CreateVisitValidator : AbstractValidator<VisitDto>
{
    public CreateVisitValidator(IGenericRepository<Visit,int> genericRepository)
    {
        RuleFor(x => x.DogId).CustomAsync( async (value, context, CancellationToken) =>
        {
            var dogIdToCheck = value;
            var dogIdInUse = await genericRepository.GetNextRecordAsync(filter: e => e.DogId == dogIdToCheck);
            if (dogIdInUse == null)
            {
                context.AddFailure("DogId", "DogId Doesnt exist!");
            }

        });
        RuleFor(x => x.GroomerShopId).CustomAsync( async (value, context, CancellationToken) =>
        {
            var groomerShopIdToCheck = value;
            var groomerShopIdInUse = await genericRepository.GetNextRecordAsync(filter: e => e.GroomerShopId == groomerShopIdToCheck);
            if (groomerShopIdInUse == null)
            {
                context.AddFailure("GroomerShopId", "GroomerShopId Doesnt exist!");
            }

        });
    }
}