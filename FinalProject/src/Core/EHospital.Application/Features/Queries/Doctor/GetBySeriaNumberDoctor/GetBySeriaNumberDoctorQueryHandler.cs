using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetBySeriaNumberPatient;

public class GetBySeriaNumberDoctorQueryHandler : IRequestHandler<GetBySeriaNumberDoctorQueryRequest, GetBySeriaNumberDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetBySeriaNumberDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetBySeriaNumberDoctorQueryResponse> Handle(GetBySeriaNumberDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        DoctorGetDTO doctorGetDTO = await _doctorService.GetDoctorBySeriaNumberAsync(request.SeriaNumber);
        GetBySeriaNumberDoctorQueryResponse response = new() { DoctorGetDTO = doctorGetDTO };
        return response;
    }
}
