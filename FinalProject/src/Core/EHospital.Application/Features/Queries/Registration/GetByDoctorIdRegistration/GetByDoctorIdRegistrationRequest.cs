using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetByDoctorIdRegistration;

public class GetByDoctorIdRegistrationRequest:IRequest<GetByDoctorIdRegistrationResponse>
{
    public string? IdStr { get; set; }
}