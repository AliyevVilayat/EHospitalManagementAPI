using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.RoomCode).IsRequired();
        builder.Property(r => r.Floor).IsRequired();

        builder.HasIndex(p => p.RoomCode).IsUnique();

        builder
        .HasOne(r => r.Service)
        .WithMany(s => s.Rooms)
        .HasForeignKey(r => r.ServiceId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
