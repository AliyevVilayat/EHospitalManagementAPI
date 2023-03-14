using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Field:BaseEntity
{
    public string? PersonField { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Service> Services { get; set; }
}
