using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Doctor.GetByNameDoctor;

public class GetByNameDoctorQueryResponse
{
    public List<DoctorGetDTO> DoctorGetDTOs { get; set; }
    public long DoctorsCount { get; set; }
}
