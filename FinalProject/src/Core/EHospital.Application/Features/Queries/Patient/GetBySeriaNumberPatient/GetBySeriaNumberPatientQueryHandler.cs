using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetBySeriaNumberPatient;

public class GetBySeriaNumberPatientQueryHandler : IRequestHandler<GetBySeriaNumberPatientQueryRequest, GetBySeriaNumberPatientQueryResponse>
{
    private readonly IPatientService _patientService;

    public GetBySeriaNumberPatientQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<GetBySeriaNumberPatientQueryResponse> Handle(GetBySeriaNumberPatientQueryRequest request, CancellationToken cancellationToken)
    {
        PatientGetDTO patientGetDTO = await _patientService.GetPatientBySeriaNumberAsync(request.SeriaNumber);
        GetBySeriaNumberPatientQueryResponse response = new() { PatientGetDTO = patientGetDTO };
        return response;
    }
}
