using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetByIdDoctor;

public class GetByIdDoctorQueryRequest:IRequest<GetByIdDoctorQueryResponse>
{
    public string? Id { get; set; }
}
