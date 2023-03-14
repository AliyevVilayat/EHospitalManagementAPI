using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EHospital.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Surname).IsRequired().HasMaxLength(100);
        builder.Property(p => p.DOB).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
        builder.Property(p => p.SeriaNumber).IsRequired();
        builder.Property(p => p.RegistrationAddress).IsRequired();
        builder.Property(p => p.CurrentAddress).IsRequired();

        builder.HasIndex(p => p.SeriaNumber).IsUnique();

        builder
        .HasOne(p => p.BloodGroup)
        .WithMany(b => b.Patients)
        .HasForeignKey(p => p.BloodGroupId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
       .HasOne(p => p.Gender)
       .WithMany(g => g.Patients)
       .HasForeignKey(p => p.GenderId)
       .IsRequired()
       .OnDelete(DeleteBehavior.Cascade);

        builder
       .HasOne(p => p.Insurance)
       .WithMany(i => i.Patients)
       .HasForeignKey(p => p.InsuranceId)
       .IsRequired()
       .OnDelete(DeleteBehavior.Cascade);

    }
}
