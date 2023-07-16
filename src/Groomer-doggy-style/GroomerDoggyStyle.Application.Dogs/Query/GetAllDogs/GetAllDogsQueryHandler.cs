using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Query.GetAllDogs;

public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, IEnumerable<DogDto>>
{
    private readonly IDogRepository _dogRepository;
    private readonly IGenericRepository<Dog, int> _gerGenericRepository;
    private readonly static DogMapper _mapper = new();
    public GetAllDogsQueryHandler(IDogRepository dogRepository, IGenericRepository<Dog, int> gerGenericRepository)
    {
        _dogRepository = dogRepository;
        _gerGenericRepository = gerGenericRepository;
    }

    public async Task<IEnumerable<DogDto>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
    {
        var dogs = await _gerGenericRepository.GetAll();
        return _mapper.MapDogsToDogsDto(dogs);
    }
}