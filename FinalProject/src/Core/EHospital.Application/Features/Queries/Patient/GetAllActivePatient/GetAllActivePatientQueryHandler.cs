using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Patient.GetAllPatient;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetAllActivePatient;

public class GetAllActivePatientQueryHandler : IRequestHandler<GetAllActivePatientQueryRequest, GetAllActivePatientQueryResponse>
{
    private readonly IPatientService _patientService;

    public GetAllActivePatientQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<GetAllActivePatientQueryResponse> Handle(GetAllActivePatientQueryRequest request, CancellationToken cancellationToken)
    {
        List<PatientGetDTO> patientGetDTOs = await _patientService.GetAllActivePatientsAsync();
        GetAllActivePatientQueryResponse response = new() { PatientGetDTOs = patientGetDTOs, PatientsCount = patientGetDTOs.Count };
        return response;
    }
}
