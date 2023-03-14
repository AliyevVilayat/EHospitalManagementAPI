using EHospital.Domain.Entities;
using EHospital.Domain.Entities.Common;
using EHospital.Domain.Entities.Identity;
using EHospital.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Contexts;

public class EHospitalDbContext :IdentityDbContext<AppUser>
{
    public EHospitalDbContext(DbContextOptions<EHospitalDbContext> options) : base(options)
    {

    }

    public DbSet<Gender> Genders { get; set; } = null!;
    public DbSet<Insurance> Insurances { get; set; } = null!;
    public DbSet<BloodGroup> BloodGroups { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Field> Fields { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Receptionist> Receptionists { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Registration> Registrations { get; set; } = null!;
    public DbSet<ResultService> ResultServices { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenderConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in datas)
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => entity.Entity.UpdatedDate = DateTime.Now,
                _ => DateTime.Now
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
