namespace EHospital.Application.DTOs;

public class InsurancePatientGetDTO
{
    public Guid Id { get; set; }
    public string? PersonInsurance { get; set; }
    public float Discount { get; set; }
}
