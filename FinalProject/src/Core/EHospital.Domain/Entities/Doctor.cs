using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Doctor:BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DOB { get; set; }
    public Guid GenderId { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public int ExperienceYear { get; set; }
    public Guid FieldId { get; set; }
    public Field Field { get; set; }  
    public float Salary { get; set; }
    public string? VOEN { get; set; }
    public string? Email { get; set; }

    public ICollection<Registration> Registrations { get; set; }
}
