using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetByIdPatient;

public class GetByIdPatientQueryHandler : IRequestHandler<GetByIdPatientQueryRequest, GetByIdPatientQueryResponse>
{
    private readonly IPatientService _patientService;

    public GetByIdPatientQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<GetByIdPatientQueryResponse> Handle(GetByIdPatientQueryRequest request, CancellationToken cancellationToken)
    {
        PatientGetDTO patientGetDTO = await _patientService.GetPatientByIdAsync(request.Id);
        GetByIdPatientQueryResponse response = new() { PatientGetDTO = patientGetDTO};
        return response;
    }
}
