using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Application.Dogs.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Query.GetDogById;

public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, DogDto>
{
    private readonly IDogRepository _dogRepository;
    private readonly static DogMapper _mapper = new();

    public GetDogByIdQueryHandler(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }
    
  

    public async Task<DogDto> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
    {
        var dog = await _dogRepository.GetDogByIdAsync(request.Id);

        if (dog is null) throw new NotFoundException("Dog not found");

        var dogDto = _mapper.MapDogToDogDto(dog);

        return dogDto;

    }
}