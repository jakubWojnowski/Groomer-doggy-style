using GroomerDoggyStyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Infrastructure.EntitiesConfigurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(n => n.Name).IsRequired();
        builder.Property(l => l.LastName).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(cp => cp.ConfirmPassword).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
    }
}