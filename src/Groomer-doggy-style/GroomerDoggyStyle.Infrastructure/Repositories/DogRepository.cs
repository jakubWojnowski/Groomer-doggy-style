using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Enums;
using GroomerDoggyStyle.Domain.Interfaces;
using GroomerDoggyStyle.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GroomerDoggyStyle.Infrastructure.Repositories;

internal class DogRepository : IDogRepository
{
    private readonly GroomerDoggyStyleDbContext _dbContext;

    public DogRepository(GroomerDoggyStyleDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Dog>> GetAllDogsAsync() => await _dbContext.Dogs.ToListAsync();
    public async Task<Dog?> GetDogByIdAsync(int id) => await _dbContext.Dogs.FirstOrDefaultAsync(o => o.Id == id);
    public async Task<int> CreateDogAsync(Dog dog, int ownerId)
    {
        dog.OwnerId = ownerId;
        await _dbContext.AddAsync(dog);
        await _dbContext.SaveChangesAsync();

        return dog.Id;
    }

    public async Task UpdateDogAsync (Dog dog, Dog dogUpdate)
    {
        if (!string.IsNullOrEmpty(dogUpdate.Name))
            dog.Name = dogUpdate.Name;
        
        if (!string.IsNullOrEmpty(dogUpdate.Breed))
            dog.Breed = dogUpdate.Breed;
        
        if (dogUpdate.Sex != Sex.Unknown)
            dog.Sex = dogUpdate.Sex;
        
        if (dogUpdate.Weight >= 0)
            dog.Weight = dogUpdate.Weight;
        
        if (dogUpdate.Age >= 0)
            dog.Age = dogUpdate.Age;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDogAsync(Dog dog)
    {
        _dbContext.Remove(dog);
        await _dbContext.SaveChangesAsync();
    }
}