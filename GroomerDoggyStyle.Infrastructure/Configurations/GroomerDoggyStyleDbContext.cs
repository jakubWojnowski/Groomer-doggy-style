using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroomerDoggyStyle.Infrastructure.Configurations;

public class GroomerDoggyStyleDbContext : DbContext
{
    public GroomerDoggyStyleDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GroomerShop> GroomerShops { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Owner> Owners { get; set; }
    
    
}