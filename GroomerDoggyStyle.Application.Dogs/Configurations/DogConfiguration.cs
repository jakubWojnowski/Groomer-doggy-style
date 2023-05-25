using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Application.Dogs.Configurations;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.Property(n => n.Name).IsRequired();
        builder.Property(w => w.Weight).IsRequired();
        
        //relation many to one with Visits
        builder
            .HasMany(d => d.Visits)
            .WithOne(v => v.Dog)
            .HasForeignKey(v => v.DogId);
        
        //one to many relation with Owner
        builder.HasOne(d => d.Owner)
            .WithMany(o => o.Dogs)
            .HasForeignKey(d => d.OwnerId);

    }
}