using GroomerDoggyStyle.Application.GroomerShops.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Query.GetAllGroomerShops;

public record GetAllGroomerShopsQuery : IRequest<IEnumerable<GroomerShopDto>>;