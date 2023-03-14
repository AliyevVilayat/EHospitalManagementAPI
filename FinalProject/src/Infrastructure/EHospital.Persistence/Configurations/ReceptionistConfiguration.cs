using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Surname).IsRequired().HasMaxLength(100);
        builder.Property(r => r.DOB).IsRequired();
        builder.Property(r => r.PhoneNumber).IsRequired();
        builder.Property(r => r.SeriaNumber).IsRequired();
        builder.Property(r => r.Salary).IsRequired();
        builder.Property(r => r.RegistrationAddress).IsRequired();
        builder.Property(r => r.CurrentAddress).IsRequired();
        builder.Property(r => r.VOEN).IsRequired();

        builder.HasIndex(d => d.SeriaNumber).IsUnique();
        builder.HasIndex(d => d.VOEN).IsUnique();


        builder
       .HasOne(r => r.Gender)
       .WithMany(g => g.Receptionists)
       .HasForeignKey(r => r.GenderId)
       .IsRequired()
       .OnDelete(DeleteBehavior.Cascade);
    }
}
