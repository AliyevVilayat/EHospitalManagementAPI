using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.DeleteDoctor;

public class DeleteDoctorCommandRequest:IRequest<DeleteDoctorCommandResponse>
{
    public string? Id { get; set; }
}
