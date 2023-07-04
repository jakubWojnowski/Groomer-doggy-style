using GroomerDoggyStyle.Domain.Entities;

namespace GroomerDoggyStyle.Domain.Interfaces;

public interface IDogRepository
{
    Task<IEnumerable<Dog>> GetAllDogsAsync();
    Task<Dog?> GetDogByIdAsync(int id);
    Task<int> CreateDogAsync(Dog dog, int ownerId);
    Task UpdateDogAsync (Dog dog, Dog dogUpdate);
    Task DeleteDogAsync(Dog dog);
}