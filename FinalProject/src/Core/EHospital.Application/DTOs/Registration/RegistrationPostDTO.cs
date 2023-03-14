namespace EHospital.Application.DTOs;

public class RegistrationPostDTO
{
    public string? PatientComplaint { get; set; }
    public string? PatientIdStr { get; set; }
    public string? DoctorIdStr { get; set; }
    public string? ServiceIdStr { get; set; }
    public string? RoomIdStr { get; set; }
    public string? ReceptionistIdStr { get; set; }
    public float AmountPaid { get; set; }
    public bool ItPaid { get; set; }
}
