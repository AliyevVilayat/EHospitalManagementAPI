using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetByIdPatient;

public class GetByIdPatientQueryRequest:IRequest<GetByIdPatientQueryResponse>
{
    public string Id { get; set; }
}
