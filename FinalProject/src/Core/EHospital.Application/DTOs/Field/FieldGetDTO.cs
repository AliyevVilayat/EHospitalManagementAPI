namespace EHospital.Application.DTOs;

public class FieldGetDTO
{
    public Guid Id { get; set; }
    public string? PersonField { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public ICollection<DoctorGetDTO> DoctorGetDTOs { get; set; }
    public ICollection<ServiceGetDTO> ServiceGetDTOs { get; set; }
    public bool IsDeleted { get; set; }
}
