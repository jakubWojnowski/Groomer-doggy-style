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
    
    public Dog MapAndUpdate(DogDto dogDto, Dog dog)
    {
        dog.Name = dogDto.Name;
        dog.Age = dogDto.Age;
        dog.Weight = dogDto.Weight;
        dog.Breed = dogDto.Breed;
        dog.Sex = dogDto.Sex;

        return dog;
    }

}