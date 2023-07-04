using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using GroomerDoggyStyle.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GroomerDoggyStyle.Infrastructure.Repositories;

internal class OwnerRepository : IOwnerRepository
{
    private readonly GroomerDoggyStyleDbContext _dbContext;
    public OwnerRepository(GroomerDoggyStyleDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Owner>> GetAllOwnersAsync() => await _dbContext.Owners.ToListAsync();
    public async Task<Owner?> GetOwnerByIdAsync(int id) => await _dbContext.Owners.FirstOrDefaultAsync(o => o.Id == id);
    public async Task<int> CreateOwnerAsync(Owner owner)
    {
        await _dbContext.AddAsync(owner);
        await _dbContext.SaveChangesAsync();

        return owner.Id;
    }

    public async Task UpdateOwnerAsync(Owner owner, Owner ownerUpdate)
    {
        owner.Name = ownerUpdate.Name;
        owner.LastName = ownerUpdate.LastName;
        owner.Mail = ownerUpdate.Mail;
        owner.PhoneNumber = ownerUpdate.PhoneNumber;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteOwnerAsync(Owner owner)
    {
        _dbContext.Remove(owner);
        await _dbContext.SaveChangesAsync();
    }
}
