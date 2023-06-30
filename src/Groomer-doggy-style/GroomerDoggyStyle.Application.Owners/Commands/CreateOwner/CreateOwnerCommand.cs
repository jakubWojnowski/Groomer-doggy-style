using GroomerDoggyStyle.Application.Owners.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Commands.CreateOwner;

public record CreateOwnerCommand(OwnerDto OwnerDto) : IRequest<int>;
