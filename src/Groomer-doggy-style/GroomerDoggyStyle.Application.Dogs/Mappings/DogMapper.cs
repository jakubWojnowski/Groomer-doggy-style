using GroomerDoggyStyle.Application.Dogs.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Dogs.Mappings;
[Mapper]
public partial class DogMapper
{
    public partial Dog MapDogDtoToDog(DogDto dogDto);
    public partial DogDto MapDogToDogDto(Dog dog);
    
    public partial IEnumerable<DogDto> MapDogsToDogsDto(IEnumerable<Dog> dogs);

}