using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    public sealed class PermitTypeConfiguration : IEntityTypeConfiguration<PermitType>
    {
        void IEntityTypeConfiguration<PermitType>.Configure(EntityTypeBuilder<PermitType> builder)
        {
            builder.Property(permitType => permitType.Description).HasMaxLength(25).IsRequired();

            builder.HasData(
                new PermitType { Id = 1, Description = "Licencia Medica" },
                new PermitType { Id = 2, Description = "Estudios" }
                );
        }
    }
}

