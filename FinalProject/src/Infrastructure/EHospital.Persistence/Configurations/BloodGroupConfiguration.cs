using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class BloodGroupConfiguration : IEntityTypeConfiguration<BloodGroup>
{
    public void Configure(EntityTypeBuilder<BloodGroup> builder)
    {
        builder.Property(b => b.PersonBloodGroup).IsRequired();
    }
}
