using GroomerDoggyStyle.Application.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Commands.CreateOwner;

public record CreateOwnerCommand(OwnerDto OwnerDto) : IRequest<int>;
