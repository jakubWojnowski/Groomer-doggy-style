using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Infrastructure.EntitiesConfigurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.Property(n => n.Name).IsRequired();
        builder.Property(p => p.Price).IsRequired();
    }
}