using GroomerDoggyStyle.Application.DTO;
using MediatR;


namespace GroomerDoggyStyle.Application.Queries.GetOwnerById;

public record GetOwnerByIdQuery(int Id) : IRequest<OwnerDto>;