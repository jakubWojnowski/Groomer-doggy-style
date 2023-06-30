using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Query.GetAllDogs;

public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, IEnumerable<DogDto>>
{
    private readonly IDogRepository _dogRepository;
    private readonly static DogMapper _mapper = new();
    public GetAllDogsQueryHandler(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    public async Task<IEnumerable<DogDto>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
    {
        var dogs = await _dogRepository.GetAllDogsAsync();
        return _mapper.MapDogsToDogsDto(dogs);
    }
}