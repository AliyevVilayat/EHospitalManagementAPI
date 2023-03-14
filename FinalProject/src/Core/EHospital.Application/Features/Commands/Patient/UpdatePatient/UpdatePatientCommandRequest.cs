using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.UpdatePatient;

public class UpdatePatientCommandRequest:IRequest<UpdatePatientCommandResponse>
{
    public PatientPutDTO PatientPutDTO { get; set; }
}
