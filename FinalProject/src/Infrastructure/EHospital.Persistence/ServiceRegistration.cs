using EHospital.Application;
using EHospital.Application.Repositories;
using EHospital.Application.Services;
using EHospital.Domain.Entities.Identity;
using EHospital.Persistence.Contexts;
using EHospital.Persistence.Repositories;
using EHospital.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EHospital.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        //DbContext
        services.AddDbContext<EHospitalDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.ConnectionString);
        });

        //Identity
        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireDigit = true;
            opt.Password.RequireNonAlphanumeric = true;

            opt.User.RequireUniqueEmail = true;

            opt.Lockout.MaxFailedAccessAttempts = 4;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            opt.Lockout.AllowedForNewUsers = true;

        }).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<EHospitalDbContext>();

        //Scopes
        services.AddScoped<EHospitalDbContextInitializer>();

        services.AddScoped<IPatientReadRepository, PatientReadRepository>();
        services.AddScoped<IPatientWriteRepository, PatientWriteRepository>();

        services.AddScoped<IInsuranceReadRepository, InsuranceReadRepository>();
        services.AddScoped<IInsuranceWriteRepository, InsuranceWriteRepository>();

        services.AddScoped<IFieldReadRepository, FieldReadRepository>();
        services.AddScoped<IFieldWriteRepository, FieldWriteRepository>();

        services.AddScoped<IDoctorReadRepository, DoctorReadRepository>();
        services.AddScoped<IDoctorWriteRepository, DoctorWriteRepository>();

        services.AddScoped<IServiceReadRepository, ServiceReadRepository>();
        services.AddScoped<IServiceWriteRepository, ServiceWriteRepository>();
        
        services.AddScoped<IReceptionistReadRepository, ReceptionistReadRepository>();
        services.AddScoped<IReceptionistWriteRepository, ReceptionistWriteRepository>();
        
        services.AddScoped<IRoomReadRepository, RoomReadRepository>();
        services.AddScoped<IRoomWriteRepository, RoomWriteRepository>();

        services.AddScoped<IRegistrationReadRepository, RegistrationReadRepository>();
        services.AddScoped<IRegistrationWriteRepository, RegistrationWriteRepository>();

        services.AddScoped<IResultServiceReadRepository, ResultServiceReadRepository>();
        services.AddScoped<IResultServiceWriteRepository, ResultServiceWriteRepository>();

        services.AddScoped<IGenderReadRepository, GenderReadRepository>();

        services.AddScoped<IBloodGroupReadRepository, BloodGroupReadRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IInsuranceService, InsuranceService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IBloodGroupService, BloodGroupService>();
        services.AddScoped<IReceptionistService, ReceptionistService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IResultServiceService, ResultServiceService>();
        services.AddScoped<IRoleService, RoleService>();        
        services.AddScoped<IUserService, UserService>();        
        services.AddScoped<IAccountService, AccountService>();        
        services.AddScoped<IAdminService, AdminService>();        
        services.AddScoped<IUnitOfWork, UnitOfWork>();        
    }
}
