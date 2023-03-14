namespace EHospital.Application.DTOs;

public class ReceptionistPutDTO
{
    public string? IdStr { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DOB { get; set; }
    public string? GenderIdStr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SeriaNumber { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public float Salary { get; set; }
    public string? VOEN { get; set; }
    public string? Email { get; set; }
}
