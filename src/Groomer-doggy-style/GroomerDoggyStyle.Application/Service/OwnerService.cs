using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Application.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GroomerDoggyStyle.Application.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly OwnerMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = new();
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
        {
            var owners = await _ownerRepository.GetAllOwnersAsync();

            var ownersDto = _mapper.MapOwnersToOwnersDto(owners);

            return ownersDto;
        }

        public async Task<OwnerDto> GetOwnerByIdAsync(int id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);

            if (owner == null)
                throw new NotFoundException("Owner not found");

            var ownerDto = _mapper.MapOwnerToOwnerDto(owner);

            return ownerDto;
        }

        public async Task<int> CreateOwnerAsync(OwnerDto ownerDto)
        {
            var owner = _mapper.MapOwnerDtoToOwner(ownerDto);

            var id = await _ownerRepository.CreateOwnerAsync(owner);

            return id;
        }

        public async Task UpdateOwnerAsync(int id, OwnerDto ownerDto)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);

            if (owner == null)
                throw new NotFoundException("Owner not found");

            var ownerUpdate = _mapper.MapOwnerDtoToOwner(ownerDto);

            await _ownerRepository.UpdateOwnerAsync(owner, ownerUpdate);
        }

        public async Task DeleteOwnerAsync(int id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);

            if (owner == null)
                throw new NotFoundException("Owner not found");

            await _ownerRepository.DeleteOwnerAsync(owner);
        }
    }
}
