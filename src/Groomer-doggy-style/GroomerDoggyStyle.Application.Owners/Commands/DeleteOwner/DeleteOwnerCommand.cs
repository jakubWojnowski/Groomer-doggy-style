using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Commands.DeleteOwner;

public record DeleteOwnerCommand(int Id) : IRequest;
