using EHospital.Domain.Entities.Common;

namespace EHospital.Domain.Entities;

public class Registration:BaseEntity
{
    public string? PatientComplaint { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service {  get; set; }
    public Guid RoomId { get; set;}
    public Room Room { get; set; }
    public Guid ReceptionistId { get; set; }
    public Receptionist Receptionist { get; set; }
    public float AmountPaid { get; set; }
    public bool ItPaid { get; set; }

    public ICollection<ResultService> ResultServices { get; set; }
}
