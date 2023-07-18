using GroomerDoggyStyle.Application.GroomerShops.DTO;
using GroomerDoggyStyle.Domain.Entities;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopUpdate;

public record UpdateGroomerShopCommand(GroomerShopDto GroomerShopDto, int Id) : IRequest;