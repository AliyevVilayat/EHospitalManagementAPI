namespace EHospital.Application.DTOs;

public class InsuranceGetDTO
{
    public Guid Id { get; set; } 
    public string? PersonInsurance { get; set; }
    public float Discount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<PatientGetDTO> PatientGetDTOs { get; set; }
}
