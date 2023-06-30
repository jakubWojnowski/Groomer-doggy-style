using GroomerDoggyStyle.Application.Owners.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Query.GetAllOwners;

public record GetAllOwnersQuery() : IRequest<IEnumerable<OwnerDto>>;
