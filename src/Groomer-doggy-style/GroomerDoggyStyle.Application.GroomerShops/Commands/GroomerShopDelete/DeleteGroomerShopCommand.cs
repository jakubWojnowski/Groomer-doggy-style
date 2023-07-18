using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopDelete;

public record DeleteGroomerShopCommand(int Id) : IRequest;
