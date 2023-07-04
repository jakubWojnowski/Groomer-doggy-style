using GroomerDoggyStyle.Application.Owners.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Owners.Query.GetOwnerById;

public record GetOwnerByIdQuery(int Id) : IRequest<OwnerDto>;