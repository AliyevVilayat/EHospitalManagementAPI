using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetByNamePatient;

public class GetByNamePatientQueryRequest:IRequest<GetByNamePatientQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
