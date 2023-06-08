using GroomerDoggyStyle.Application.DTO;
using MediatR;


namespace GroomerDoggyStyle.Application.Queries.GetOwnerById
{
    public class GetOwnerByIdQuery : IRequest<OwnerDto>
    {
        public int Id { get; set; }

        public GetOwnerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
