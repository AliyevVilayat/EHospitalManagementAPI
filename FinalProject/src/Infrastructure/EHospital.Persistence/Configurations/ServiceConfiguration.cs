using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Cost).IsRequired();

        builder
        .HasOne(s => s.Field)
        .WithMany(f => f.Services)
        .HasForeignKey(s => s.FieldId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
