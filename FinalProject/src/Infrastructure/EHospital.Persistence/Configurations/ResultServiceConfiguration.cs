using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class ResultServiceConfiguration : IEntityTypeConfiguration<ResultService>
{
    public void Configure(EntityTypeBuilder<ResultService> builder)
    {
        builder.Property(r => r.Result).IsRequired();
        
        builder
        .HasOne(r => r.Registration)
        .WithMany(p => p.ResultServices)
        .HasForeignKey(r => r.RegistrationId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
