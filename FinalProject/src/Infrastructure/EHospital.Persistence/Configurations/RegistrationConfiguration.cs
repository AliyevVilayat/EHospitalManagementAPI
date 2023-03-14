using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.Property(r => r.PatientComplaint).IsRequired();
        builder.Property(r => r.AmountPaid).IsRequired();
        builder.Property(r => r.ItPaid).IsRequired();

        builder
        .HasOne(r => r.Patient)
        .WithMany(p => p.Registrations)
        .HasForeignKey(r => r.PatientId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(r => r.Doctor)
        .WithMany(d => d.Registrations)
        .HasForeignKey(r => r.DoctorId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(r => r.Service)
        .WithMany(s => s.Registrations)
        .HasForeignKey(r => r.ServiceId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(r => r.Room)
        .WithMany(rm => rm.Registrations)
        .HasForeignKey(r => r.RoomId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(r => r.Receptionist)
        .WithMany(rt => rt.Registrations)
        .HasForeignKey(r => r.ReceptionistId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
