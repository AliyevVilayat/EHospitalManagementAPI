using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Insurance:BaseEntity
{
    public string? PersonInsurance { get; set; }
    public float Discount { get; set; }
    public ICollection<Patient> Patients { get; set; }
}
