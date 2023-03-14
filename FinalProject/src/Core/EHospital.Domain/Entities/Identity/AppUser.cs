using Microsoft.AspNetCore.Identity;

namespace EHospital.Domain.Entities.Identity;

public class AppUser:IdentityUser
{
    public string? Fullname { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
