using GroomerDoggyStyle.Application.Dogs.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.UpdateDog;


public record UpdateDogCommand(int Id, DogDto DogDto) : IRequest;