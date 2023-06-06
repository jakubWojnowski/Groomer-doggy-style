using GroomerDoggyStyle.Application.DTO;

namespace GroomerDoggyStyle.Application.Service
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
        Task<OwnerDto> GetOwnerByIdAsync(int id);
        Task<int> CreateOwnerAsync(OwnerDto ownerDto);
        Task UpdateOwnerAsync(int id, OwnerDto ownerDto);
        Task DeleteOwnerAsync(int id);
    }
}