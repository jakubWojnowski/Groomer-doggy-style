using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroomerDoggyStyle.Application.Employee.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Domain.Entities.Employee>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Employee> builder)
    {
        builder.Property(n => n.Name).IsRequired();
        builder.Property(l => l.LastName).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(cp => cp.ConfirmPassword).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
    }
}