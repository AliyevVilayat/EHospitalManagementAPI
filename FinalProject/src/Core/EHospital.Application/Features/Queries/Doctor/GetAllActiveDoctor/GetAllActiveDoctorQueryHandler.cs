using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Doctor.GetAllDoctor;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetAllActiveDoctor;

public class GetAllActiveDoctorQueryHandler : IRequestHandler<GetAllActiveDoctorQueryRequest, GetAllActiveDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetAllActiveDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    public async Task<GetAllActiveDoctorQueryResponse> Handle(GetAllActiveDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        List<DoctorGetDTO> doctorGetDTOs = await _doctorService.GetAllActiveDoctorsAsync();
        GetAllActiveDoctorQueryResponse response = new() { DoctorGetDTOs = doctorGetDTOs,DoctorsCount=doctorGetDTOs.Count };
        return response;
    }
}

