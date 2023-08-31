using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;

public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
{
    private readonly IDogRepository _dogRepository;
    private readonly IGenericRepository<Dog, int> _genericRepository;
    private readonly static DogMapper _mapper = new();

    public CreateDogCommandHandler(IDogRepository dogRepository, IGenericRepository<Dog,int> genericRepository)
    {
        _dogRepository = dogRepository;
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
    {
        var dog = _mapper.MapDogDtoToDog(request.DogDto);
        dog.OwnerId = request.Id;
        var id = await _genericRepository.Add(dog);
        return id;
    }
}