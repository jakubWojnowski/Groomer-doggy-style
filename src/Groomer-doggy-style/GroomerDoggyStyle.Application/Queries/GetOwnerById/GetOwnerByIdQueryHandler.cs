using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Queries.GetOwnerById
{
    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerDto>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly OwnerMapper _mapper;
        public GetOwnerByIdQueryHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = new();
        }
        public async Task<OwnerDto> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(request.Id);

            if (owner == null)
                throw new NotFoundException("Owner not found");

            var ownerDto = _mapper.MapOwnerToOwnerDto(owner);

            return ownerDto;
        }
    }
}
