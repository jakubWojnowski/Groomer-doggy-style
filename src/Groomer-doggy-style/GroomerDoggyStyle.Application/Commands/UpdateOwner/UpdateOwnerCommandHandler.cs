using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Commands.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly OwnerMapper _mapper;
        public UpdateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = new();
        }
        public async Task Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(request.Id);

            if (owner == null)
                throw new NotFoundException("Owner not found");

            var ownerUpdate = _mapper.MapOwnerDtoToOwner(request);

            await _ownerRepository.UpdateOwnerAsync(owner, ownerUpdate);
        }
    }
}
