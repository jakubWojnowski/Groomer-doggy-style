using GroomerDoggyStyle.Application.Dogs.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.CreateDog;

public record CreateDogCommand(DogDto DogDto, int Id) : IRequest<int>;