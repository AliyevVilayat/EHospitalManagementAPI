using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.CreateDoctor;

public class CreateDoctorCommandRequest:IRequest<CreateDoctorCommandResponse>
{
    public DoctorPostDTO DoctorPostDTO { get; set; }
}
