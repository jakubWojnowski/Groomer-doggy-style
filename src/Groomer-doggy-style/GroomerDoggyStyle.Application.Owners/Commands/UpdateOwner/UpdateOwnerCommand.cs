using GroomerDoggyStyle.Application.Owners.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Commands.UpdateOwner;

public record UpdateOwnerCommand(int Id, OwnerDto OwnerDto) : IRequest;
