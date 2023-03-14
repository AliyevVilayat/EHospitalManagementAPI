using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetBySeriaNumberPatient;

public class GetBySeriaNumberPatientQueryRequest:IRequest<GetBySeriaNumberPatientQueryResponse>
{
    public string? SeriaNumber { get; set; }
}
