using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Infrastructure.EntitiesConfigurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.Property(d => d.DateOfVisit).IsRequired();
        builder.Property(dt => dt.DurationInMinutes).IsRequired();
    }
}