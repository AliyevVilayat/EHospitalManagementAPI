using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.DeleteReceptionist;

public class DeleteReceptionistCommandRequest:IRequest<DeleteReceptionistCommandResponse>
{
    public string? IdStr { get; set; }
}
