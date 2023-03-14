using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Doctor.GetAllDoctor;

public class GetAllDoctorQueryResponse
{
    public List<DoctorGetDTO> DoctorGetDTOs { get; set; }
    public long DoctorsCount { get; set; }
}
