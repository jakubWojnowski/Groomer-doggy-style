using MediatR;

namespace GroomerDoggyStyle.Application.Commands.DeleteOwner
{
    public class DeleteOwnerCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOwnerCommand(int id)
        {
            Id = id;
        }
    }
}
