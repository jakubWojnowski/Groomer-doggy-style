using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;

public class UpdateDogCommandHandler : IRequestHandler<UpdateDogCommand>
{
    private readonly IDogRepository _dogRepository;
    private readonly static DogMapper _mapper = new();
    public UpdateDogCommandHandler(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }
    public async Task Handle(UpdateDogCommand request, CancellationToken cancellationToken)
    {
        var dog = await _dogRepository.GetDogByIdAsync(request.Id);

        if (dog is null) throw new NotFoundException("Dogo not found");

        var dogUpdate = _mapper.MapDogDtoToDog(request.DogDto);


        await _dogRepository.UpdateDogAsync(dog, dogUpdate);

    }
}