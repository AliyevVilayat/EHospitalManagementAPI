using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetByNamePatient;

public class GetByNamePatientQueryHandler : IRequestHandler<GetByNamePatientQueryRequest, GetByNamePatientQueryResponse>
{
    private readonly IPatientService _patientService;

    public GetByNamePatientQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<GetByNamePatientQueryResponse> Handle(GetByNamePatientQueryRequest request, CancellationToken cancellationToken)
    {
        List<PatientGetDTO> patientGetDTOs = await _patientService.GetPatientByNameAsync(request.Page, request.Size, request.Name);
        GetByNamePatientQueryResponse response = new() { PatientGetDTOs = patientGetDTOs,PatientsCount=patientGetDTOs.Count };
        return response;
    }
}
