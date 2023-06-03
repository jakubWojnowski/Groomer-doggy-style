using GroomerDoggyStyle.Application.DTO;

namespace GroomerDoggyStyle.Application.Service
{
    public interface IOwnerService
    {
        Task<int> CreateOwnerAsync(OwnerDto ownerDto);
    }
}