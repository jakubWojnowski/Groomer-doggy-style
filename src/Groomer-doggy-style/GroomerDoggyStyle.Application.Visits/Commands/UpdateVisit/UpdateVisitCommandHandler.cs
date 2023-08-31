using FluentValidation;
using GroomerDoggyStyle.Application.Visits.DTO;
using GroomerDoggyStyle.Application.Visits.Mapping;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Visits.Commands.UpdateVisit;

public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand>
{
    private readonly IGenericRepository<Visit, int> _genericRepository;
    private readonly IValidator<VisitDto> _validator;
    private static readonly VisitMapper _mapper = new();

    public UpdateVisitCommandHandler(IGenericRepository<Visit, int> genericRepository, IValidator<VisitDto> validator)
    {
        _genericRepository = genericRepository;
        _validator = validator;
    }
    public async Task Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = _validator.ValidateAsync(request.VisitDto, cancellationToken);
        if (!validatorResult.Result.IsValid) throw new ValidationException(validatorResult.Result.Errors);
        
        var visitToUpdate = await _genericRepository.GetById(request.Id);
        if (visitToUpdate is null) throw new NotFoundException("Visit doesn't exist");
        var visit = _mapper.MapAndUpdateVisit(request.VisitDto, visitToUpdate);
        await _genericRepository.Update(visit);
    }
}