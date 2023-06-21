using GroomerDoggyStyle.Application.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Commands.UpdateOwner;

public record UpdateOwnerCommand(int Id, OwnerDto OwnerDto) : IRequest;
