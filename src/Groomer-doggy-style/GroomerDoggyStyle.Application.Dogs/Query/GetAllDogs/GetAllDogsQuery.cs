using GroomerDoggyStyle.Application.Dogs.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Query.GetAllDogs;


    public record GetAllDogsQuery() : IRequest<IEnumerable<DogDto>>;
