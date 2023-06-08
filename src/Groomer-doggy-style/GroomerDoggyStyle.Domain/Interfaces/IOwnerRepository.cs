using GroomerDoggyStyle.Domain.Entities;


namespace GroomerDoggyStyle.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(int id);
        Task<int> CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner, Owner ownerUpdate);
        Task DeleteOwnerAsync(Owner owner);
    }
}
