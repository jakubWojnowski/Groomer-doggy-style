using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.DeleteAddress;

public record DeleteAddressCommand(int Id) : IRequest;
