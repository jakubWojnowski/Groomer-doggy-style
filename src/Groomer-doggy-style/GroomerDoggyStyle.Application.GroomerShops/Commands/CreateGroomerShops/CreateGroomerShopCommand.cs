using GroomerDoggyStyle.Application.GroomerShops.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.CreateGroomerShops;

public record CreateGroomerShopCommand(GroomerShopDto GroomerShopDto) : IRequest<int>;
