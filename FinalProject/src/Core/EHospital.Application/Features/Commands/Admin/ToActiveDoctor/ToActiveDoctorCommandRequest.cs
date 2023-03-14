using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveDoctor;

public class ToActiveDoctorCommandRequest:IRequest<ToActiveDoctorCommandResponse>
{
    public string? Id { get; set; }
}