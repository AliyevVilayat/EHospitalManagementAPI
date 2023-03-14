using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Gender:BaseEntity
{
    public string? PersonGender { get; set; }
    public ICollection<Patient> Patients { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Receptionist> Receptionists { get; set; }
}
