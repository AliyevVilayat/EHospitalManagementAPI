using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetByNameDoctor;

public class GetByNameDoctorQueryRequest:IRequest<GetByNameDoctorQueryResponse>
{
    public string? Name { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}
