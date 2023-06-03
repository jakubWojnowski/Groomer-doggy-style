using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;


namespace GroomerDoggyStyle.Application.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task<int> CreateOwnerAsync(OwnerDto ownerDto)
        {
            var mapper = new OwnerMapper();
            var owner = mapper.MapOwnerDtoToOwner(ownerDto);

            var id = await _ownerRepository.CreateOwnerAsync(owner);

            return id;
        }
    }
}
