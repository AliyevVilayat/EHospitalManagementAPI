using EHospital.Application.Features.Commands.Patient.UpdatePatient;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.DeletePatient;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommandRequest, DeletePatientCommandResponse>
{
    private readonly IPatientService _patientService;

    public DeletePatientCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<DeletePatientCommandResponse> Handle(DeletePatientCommandRequest request, CancellationToken cancellationToken)
    {
        await _patientService.DeletePatientAsync(request.Id);
        DeletePatientCommandResponse response = new() { Message = "Patient successfully updated" };
        return response;
    }
}
