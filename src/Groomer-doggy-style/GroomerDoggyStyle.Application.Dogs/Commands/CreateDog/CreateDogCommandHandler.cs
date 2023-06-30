using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;

public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
{
    private readonly IDogRepository _dogRepository;
    private readonly static DogMapper _mapper = new();

    public CreateDogCommandHandler(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }
    public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
    {
        var dog = _mapper.MapDogDtoToDog(request.DogDto);

        var id = await _dogRepository.CreateDogAsync(dog, request.OwnerId);
        return id;
    }
}