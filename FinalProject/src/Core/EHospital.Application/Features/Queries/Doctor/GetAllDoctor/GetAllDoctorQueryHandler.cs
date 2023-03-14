using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetAllDoctor;

public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQueryRequest, GetAllDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetAllDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetAllDoctorQueryResponse> Handle(GetAllDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        List<DoctorGetDTO> doctorGetDTOs = await _doctorService.GetAllDoctorsAsync();
        GetAllDoctorQueryResponse response = new() { DoctorGetDTOs = doctorGetDTOs, DoctorsCount = doctorGetDTOs.Count };
        return response;
    }
}
