using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.UpdatePatient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommandRequest, UpdatePatientCommandResponse>
{
    private readonly IPatientService _patientService;

    public UpdatePatientCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<UpdatePatientCommandResponse> Handle(UpdatePatientCommandRequest request, CancellationToken cancellationToken)
    {
        await _patientService.UpdatePatientAsync(request.PatientPutDTO);
        UpdatePatientCommandResponse response = new() { Message = "Patient successfully updated" };
        return response;
    }
}
