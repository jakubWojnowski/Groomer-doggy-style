using GroomerDoggyStyle.Application.Service;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using GroomerDoggyStyle.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroomerDoggyStyle.Infrastructure.Repositories
{
    internal class OwnerRepository : IOwnerRepository
    {
        private readonly GroomerDoggyStyleDbContext _dbContext;
        public OwnerRepository(GroomerDoggyStyleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateOwnerAsync(Owner owner)
        {
            await _dbContext.AddAsync(owner);
            await _dbContext.SaveChangesAsync();
        }
    }
}
