using MediatR;

namespace GroomerDoggyStyle.Application.Commands.DeleteOwner;

public record DeleteOwnerCommand(int Id) : IRequest;
