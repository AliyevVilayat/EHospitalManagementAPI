using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetAllPatient;

public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQueryRequest, GetAllPatientQueryResponse>
{
    private readonly IPatientService _patientService;

    public GetAllPatientQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<GetAllPatientQueryResponse> Handle(GetAllPatientQueryRequest request, CancellationToken cancellationToken)
    {
        List<PatientGetDTO> patientGetDTOs = await _patientService.GetAllPatientsAsync();
        GetAllPatientQueryResponse response = new() { PatientGetDTOs = patientGetDTOs, PatientsCount = patientGetDTOs.Count };
        return response;
    }
}
