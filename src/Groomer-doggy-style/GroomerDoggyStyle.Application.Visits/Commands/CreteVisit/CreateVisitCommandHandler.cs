using FluentValidation;
using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Application.Visits.Mapping;
using GroomerDoggyStyle.Application.Visits.Validators;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.CreteVisit;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, int>
{
    private readonly IGenericRepository<Visit, int> _genericVisitRepository;
    private readonly IValidator<VisitDto> _validator;

    private static VisitMapper _mapper = new();

    public CreateVisitCommandHandler(IGenericRepository<Visit, int> genericVisitRepository, IValidator<VisitDto> validator)
    {
        _genericVisitRepository = genericVisitRepository;
        _validator = validator;
    }
    public async Task<int> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.VisitDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var visit = _mapper.MapVisitDtoToVisit(request.VisitDto);
     
        var id = await _genericVisitRepository.Add(visit);
        return id;
    }
}