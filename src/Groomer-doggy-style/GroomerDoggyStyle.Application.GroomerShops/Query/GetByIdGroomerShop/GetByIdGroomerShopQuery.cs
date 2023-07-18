using GroomerDoggyStyle.Application.GroomerShops.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Query.GroomerShopGetById;

public record GetByIdGroomerShopQuery(int Id) : IRequest<GroomerShopDto>;