using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using GroomerDoggyStyle.Infrastructure.Persistence;

namespace GroomerDoggyStyle.Infrastructure.Repositories
{
    internal class OwnerRepository : IOwnerRepository
    {
        private readonly GroomerDoggyStyleDbContext _dbContext;
        public OwnerRepository(GroomerDoggyStyleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateOwnerAsync(Owner owner)
        {
            await _dbContext.AddAsync(owner);
            await _dbContext.SaveChangesAsync();

            return owner.Id;
        }
    }
}
