using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Doctor.GetByNameDoctor;

public class GetByNameDoctorQueryHandler : IRequestHandler<GetByNameDoctorQueryRequest, GetByNameDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetByNameDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    public async Task<GetByNameDoctorQueryResponse> Handle(GetByNameDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        List<DoctorGetDTO> doctorGetDTOs = await _doctorService.GetDoctorByNameAsync(request.Page,request.Size,request.Name);
        GetByNameDoctorQueryResponse response = new() { DoctorGetDTOs = doctorGetDTOs, DoctorsCount = doctorGetDTOs.Count };
        return response;
    }
}
