using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    public sealed class PermitConfiguration : IEntityTypeConfiguration<Permit>
    {
        void IEntityTypeConfiguration<Permit>.Configure(EntityTypeBuilder<Permit> builder)
        {
            builder.Property(permit => permit.EmployeeName).HasMaxLength(30).IsRequired();
            builder.Property(permit => permit.EmployeeLastName).HasMaxLength(30).IsRequired();
            builder.Property(permit => permit.Date).IsRequired();
        }
    }
}
