using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Registration.GetAllRegistration;

public class GetAllRegistrationQueryResponse
{
    public List<RegistrationGetDTO> RegistrationGetDTOs { get; set; }
    public long RegistrationsCount { get; set; }
}
