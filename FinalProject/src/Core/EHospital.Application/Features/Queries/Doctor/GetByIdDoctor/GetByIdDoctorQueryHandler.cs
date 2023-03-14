using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetByIdDoctor;

public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQueryRequest, GetByIdDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetByIdDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetByIdDoctorQueryResponse> Handle(GetByIdDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        DoctorGetDTO doctorGetDTO = await _doctorService.GetDoctorByIdAsync(request.Id);
        GetByIdDoctorQueryResponse response = new() { DoctorGetDTO = doctorGetDTO };
        return response;
    }
}
