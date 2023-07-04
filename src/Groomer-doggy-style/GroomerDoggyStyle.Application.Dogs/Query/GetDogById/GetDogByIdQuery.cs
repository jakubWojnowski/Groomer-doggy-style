using GroomerDoggyStyle.Application.Dogs.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Query.GetDogById;


public record GetDogByIdQuery(int Id) : IRequest<DogDto>;


