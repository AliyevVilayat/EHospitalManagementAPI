using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.UpdateDoctor;

public class UpdateDoctorCommandRequest:IRequest<UpdateDoctorCommandResponse>
{
    public DoctorPutDTO DoctorPutDTO { get; set; }
}
