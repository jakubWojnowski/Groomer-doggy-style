using GroomerDoggyStyle.Application.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Queries.GetAllOwners
{
    public class GetAllOwnersQuery : IRequest<IEnumerable<OwnerDto>>
    {
    }
}
