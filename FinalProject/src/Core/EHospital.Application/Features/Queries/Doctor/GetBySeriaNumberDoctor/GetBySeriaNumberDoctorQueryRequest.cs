using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetBySeriaNumberPatient;

public class GetBySeriaNumberDoctorQueryRequest:IRequest<GetBySeriaNumberDoctorQueryResponse>
{
    public string? SeriaNumber { get; set; }
}
