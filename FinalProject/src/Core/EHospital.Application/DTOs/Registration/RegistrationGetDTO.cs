using EHospital.Domain.Entities;

namespace EHospital.Application.DTOs;

public class RegistrationGetDTO
{
    public Guid Id { get; set; }
    public string? PatientComplaint { get; set; }
    public PatientGetDTO PatientGetDTO { get; set; }
    public DoctorGetDTO DoctorGetDTO { get; set; }
    public ServiceGetDTO ServiceGetDTO { get; set; }
    public RoomGetDTO RoomGetDTO { get; set; }
    public ReceptionistGetDTO ReceptionistGetDTO { get; set; }
    public float AmountPaid { get; set; }
    public bool ItPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
