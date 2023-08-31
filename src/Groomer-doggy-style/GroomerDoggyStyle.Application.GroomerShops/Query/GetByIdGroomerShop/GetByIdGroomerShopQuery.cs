using GroomerDoggyStyle.Application.GroomerShops.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Query.GetByIdGroomerShop;

public record GetByIdGroomerShopQuery(int Id) : IRequest<GroomerShopDto>;