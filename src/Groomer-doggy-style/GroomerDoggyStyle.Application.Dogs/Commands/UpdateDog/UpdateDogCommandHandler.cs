using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;

public class UpdateDogCommandHandler : IRequestHandler<UpdateDogCommand>
{
    private readonly IDogRepository _dogRepository;
    private readonly IGenericRepository<Dog, int> _genericRepository;
    private readonly static DogMapper _mapper = new();
    public UpdateDogCommandHandler(IDogRepository dogRepository, IGenericRepository<Dog, int> genericRepository)
    {
        _dogRepository = dogRepository;
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateDogCommand request, CancellationToken cancellationToken)
    {
        var dog = await _genericRepository.GetById(request.Id);

        if (dog is null) throw new NotFoundException("Dogo not found");

        var dogUpdate = _mapper.MapAndUpdate(request.DogDto, dog);


        await _genericRepository.Update(dogUpdate);

    }
}