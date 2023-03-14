using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Surname).IsRequired().HasMaxLength(100);
        builder.Property(d => d.DOB).IsRequired();
        builder.Property(d => d.PhoneNumber).IsRequired();
        builder.Property(d => d.SeriaNumber).IsRequired();
        builder.Property(d => d.ExperienceYear).IsRequired();
        builder.Property(d => d.Salary).IsRequired();
        builder.Property(d => d.RegistrationAddress).IsRequired();
        builder.Property(d => d.CurrentAddress).IsRequired();
        builder.Property(d => d.VOEN).IsRequired();

        builder.HasIndex(d => d.SeriaNumber).IsUnique();
        builder.HasIndex(d => d.VOEN).IsUnique();

        builder
        .HasOne(d => d.Field)
        .WithMany(f => f.Doctors)
        .HasForeignKey(d => d.FieldId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
       .HasOne(d => d.Gender)
       .WithMany(g => g.Doctors)
       .HasForeignKey(d => d.GenderId)
       .IsRequired()
       .OnDelete(DeleteBehavior.Cascade);
    }
}
