using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Registration.GetByDoctorIdRegistration;

public class GetByDoctorIdRegistrationResponse
{
    public List<RegistrationGetDTO> RegistrationGetDTOs { get; set; }
    public long RegistrationsCount { get; set; }
}