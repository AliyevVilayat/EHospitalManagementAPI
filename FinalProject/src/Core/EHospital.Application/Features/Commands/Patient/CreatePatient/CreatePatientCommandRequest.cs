using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.CreatePatient;

public class CreatePatientCommandRequest:IRequest<CreatePatientCommandResponse>
{
    public PatientPostDTO PatientPostDTO { get; set; }
}
