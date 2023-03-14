using EHospital.Domain.Entities;
using EHospital.Domain.Entities.Identity;
using EHospital.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EHospital.Persistence.Contexts;

public class EHospitalDbContextInitializer
{
    private readonly EHospitalDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public EHospitalDbContextInitializer(EHospitalDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task CreateBloodGroups()
    {
        if (_context.BloodGroups.Count() == 0)
        {
            List<BloodGroup> bloodGroups = new()
            {
                new() { PersonBloodGroup = "A+"},
                new() { PersonBloodGroup = "A-"},
                new() { PersonBloodGroup = "B+"},
                new() { PersonBloodGroup = "B-"},
                new() { PersonBloodGroup = "AB+"},
                new() { PersonBloodGroup = "AB-"},
                new() { PersonBloodGroup = "O+"},
                new() { PersonBloodGroup = "O-"}
            };
            await _context.BloodGroups.AddRangeAsync(bloodGroups);
            await _context.SaveChangesAsync();
        }
    }

    public async Task CreateGenders()
    {
        if (_context.Genders.Count() == 0)
        {
            List<Gender> genders = new()
            {
                new() { PersonGender = "Male"},
                new() { PersonGender = "Female"}
            };
            await _context.Genders.AddRangeAsync(genders);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RoleSeedAsync()
    {

        foreach (var role in Enum.GetValues(typeof(Roles)))
        {

            if (!await _roleManager.RoleExistsAsync(role.ToString()))
            {

                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }

    public async Task UserSeedAsync()
    {       
        if (_userManager.Users.Count() == 0)
        {
            AppUser userAdmin = new();
            userAdmin.Fullname = Configuration.ConfigManager["AdminSettings:Fullname"];
            userAdmin.UserName = _configuration["AdminSettings:Username"];
            userAdmin.Email = _configuration["AdminSettings:Email"];
            userAdmin.CreatedDate = DateTime.Now;
            IdentityResult identityResult = await _userManager.CreateAsync(userAdmin, _configuration["AdminSettings:Password"]);
            if (identityResult.Succeeded)
            {

            }
            await _userManager.AddToRoleAsync(userAdmin, Roles.Admin.ToString());
        }
    }
}
