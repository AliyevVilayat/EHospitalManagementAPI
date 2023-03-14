using MediatR;

namespace EHospital.Application.Features.Queries.Registration.GetByIdRegistration;

public class GetByIdRegistrationQueryRequest:IRequest<GetByIdRegistrationQueryResponse>
{
    public string IdStr { get; set; }
}
