using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Infrastructure.EntitiesConfigurations;

internal sealed class GroomerShopConfiguration : IEntityTypeConfiguration<GroomerShop>
{
    public void Configure(EntityTypeBuilder<GroomerShop> builder)
    {

        builder.Property(n => n.Name).IsRequired();
        builder.Property(m => m.Mail).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
        
        //relation one to one with Address
        builder
            .HasOne(gs => gs.Address)
            .WithOne(a => a.GroomerShop)
            .HasForeignKey<GroomerShop>(gs => gs.AddressId);
        
        //many to one relation with visits
        builder
            .HasMany(gs => gs.Visits)
            .WithOne(v => v.GroomerShop)
            .HasForeignKey(v => v.GroomerShopId);
        
        //many to one relation with Employees
        builder
            .HasMany(gs => gs.Employees)
            .WithOne(e => e.GroomerShop)
            .HasForeignKey(e => e.GroomerShopId);
        
        //many to many relation offer with GroomerShop
        builder
            .HasMany(gs => gs.Offers)
            .WithMany(o => o.GroomerShops);

    }
}