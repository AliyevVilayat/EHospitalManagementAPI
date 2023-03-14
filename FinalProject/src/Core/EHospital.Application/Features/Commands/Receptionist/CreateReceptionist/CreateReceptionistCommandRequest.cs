using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;

public class CreateReceptionistCommandRequest:IRequest<CreateReceptionistCommandResponse>
{
    public ReceptionistPostDTO ReceptionistPostDTO { get; set; }
}
