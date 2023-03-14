using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Registration.GetAllActiveRegistration;

public class GetAllActiveRegistrationQueryResponse
{
    public List<RegistrationGetDTO> RegistrationGetDTOs { get; set; }
    public long RegistrationsCount { get; set; }
}
