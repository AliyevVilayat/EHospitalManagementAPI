using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.UpdateReceptionist;

public class UpdateReceptionistCommandRequest:IRequest<UpdateReceptionistCommandResponse>
{
    public ReceptionistPutDTO ReceptionistPutDTO { get; set; }
}
