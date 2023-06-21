using GroomerDoggyStyle.Application.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Queries.GetAllOwners;

public record GetAllOwnersQuery() : IRequest<IEnumerable<OwnerDto>>;
