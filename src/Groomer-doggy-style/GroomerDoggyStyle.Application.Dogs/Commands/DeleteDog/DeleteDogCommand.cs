using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.DeleteDog;

public record DeleteDogCommand(int Id) : IRequest;