using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Doctor.GetAllActiveDoctor;

public class GetAllActiveDoctorQueryResponse
{
    public List<DoctorGetDTO> DoctorGetDTOs { get; set; }
    public long DoctorsCount { get; set; }
}
