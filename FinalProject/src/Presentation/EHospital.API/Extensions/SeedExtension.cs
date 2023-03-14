using EHospital.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EHospital.Persistence;

public static class SeedExtension
{
    public static async Task AddSeeder(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<EHospitalDbContextInitializer>();
            await initializer.InitializeAsync();
            await initializer.CreateBloodGroups();
            await initializer.CreateGenders();
            await initializer.RoleSeedAsync();
            await initializer.UserSeedAsync();
        }
    }
}
