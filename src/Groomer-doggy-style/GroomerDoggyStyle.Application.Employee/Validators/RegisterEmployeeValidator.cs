using FluentValidation;
using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Domain.Interfaces;

namespace GroomerDoggyStyle.Application.Employee.Validators;
 
public class RegisterEmployeeValidator : AbstractValidator<RegisterEmployeeDto>
{
    public RegisterEmployeeValidator(IGenericRepository<Domain.Entities.Employee, int> genericRepository)
    {
        RuleFor(x => x.Mail)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Mail)
            .CustomAsync(async (value, context, cancellationToken) =>
            {
                var emailToCheck = value; // Capture the email value here
                var emailInUse = await genericRepository.GetNextRecordAsync(filter: e => e.Mail == emailToCheck);
                if (emailInUse != null)
                {
                    context.AddFailure("Email", "Email is taken!");
                }
            });
        RuleFor(x => x.Password)
            .MinimumLength(8);
        RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
    }

    
}