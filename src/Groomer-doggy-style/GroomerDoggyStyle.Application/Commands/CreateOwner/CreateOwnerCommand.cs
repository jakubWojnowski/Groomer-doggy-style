using GroomerDoggyStyle.Application.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Commands.CreateOwner
{
    public class CreateOwnerCommand : OwnerDto, IRequest<int>
    {

    }
}
