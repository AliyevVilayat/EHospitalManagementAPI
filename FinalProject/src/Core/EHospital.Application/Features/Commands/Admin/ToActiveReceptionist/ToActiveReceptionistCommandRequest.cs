using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveReceptionist;

public class ToActiveReceptionistCommandRequest:IRequest<ToActiveReceptionistCommandResponse>
{
    public string? Id { get; set; }
}