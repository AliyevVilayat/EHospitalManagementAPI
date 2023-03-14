using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class BloodGroup:BaseEntity
{
    public string? PersonBloodGroup { get; set; }
    public ICollection<Patient> Patients { get; set; }
}
