namespace EHospital.Application.DTOs;

public class CheckDTO
{
    public string? PatientFullName { get; set;}
    public string? DoctorFullName { get; set;}
    public string? ReceptionistFullName { get; set;}
    public string? ServiceName { get; set;}
    public string? RoomCode { get; set; }
    public float AmountPaid { get; set; }
    public DateTime PrintDate { get; set; }
}
