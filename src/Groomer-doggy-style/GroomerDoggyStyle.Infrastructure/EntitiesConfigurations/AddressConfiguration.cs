using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Infrastructure.EntitiesConfigurations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(c => c.Country).IsRequired();
        builder.Property(ci => ci.City).IsRequired();
        builder.Property(s => s.Street).IsRequired();
        builder.Property(b => b.BuildingNumber).IsRequired();
        builder.Property(p => p.PostalCode).IsRequired();
      
    }
}