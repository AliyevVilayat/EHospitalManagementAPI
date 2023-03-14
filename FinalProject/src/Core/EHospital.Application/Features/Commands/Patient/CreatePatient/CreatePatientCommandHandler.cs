using EHospital.Application.Features.Commands.Patient.DeletePatient;
using EHospital.Application.Repositories;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.CreatePatient;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommandRequest, CreatePatientCommandResponse>
{
    private readonly IPatientService _patientService;

    public CreatePatientCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<CreatePatientCommandResponse> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
    {
        await _patientService.CreatePatientAsync(request.PatientPostDTO);
        CreatePatientCommandResponse response = new() { Message = "Patient successfully created" };
        return response;
    }
}
