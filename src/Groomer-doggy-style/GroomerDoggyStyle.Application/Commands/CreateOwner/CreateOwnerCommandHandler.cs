using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;


namespace GroomerDoggyStyle.Application.Commands.CreateOwner
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly OwnerMapper _mapper;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = new();
        }
        public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = _mapper.MapOwnerDtoToOwner(request);

            var id = await _ownerRepository.CreateOwnerAsync(owner);

            return id;
        }
    }
}
