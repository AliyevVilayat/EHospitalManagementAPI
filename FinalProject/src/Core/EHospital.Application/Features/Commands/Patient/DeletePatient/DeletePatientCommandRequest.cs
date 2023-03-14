using MediatR;

namespace EHospital.Application.Features.Commands.Patient.DeletePatient;

public class DeletePatientCommandRequest:IRequest<DeletePatientCommandResponse>
{
    public string? Id { get; set; }
}
