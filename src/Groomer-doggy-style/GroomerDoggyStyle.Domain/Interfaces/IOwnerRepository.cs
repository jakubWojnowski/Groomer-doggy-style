using GroomerDoggyStyle.Domain.Entities;


namespace GroomerDoggyStyle.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        Task<int> CreateOwnerAsync(Owner owner);
    }
}
