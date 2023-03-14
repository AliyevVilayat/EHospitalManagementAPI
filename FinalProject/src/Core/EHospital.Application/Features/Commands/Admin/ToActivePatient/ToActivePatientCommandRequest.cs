using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActivePatient;

public class ToActivePatientCommandRequest:IRequest<ToActivePatientCommandResponse>
{
    public string? Id { get; set; }
}