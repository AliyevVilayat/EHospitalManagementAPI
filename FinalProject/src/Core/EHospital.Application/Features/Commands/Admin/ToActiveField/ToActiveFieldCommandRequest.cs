using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveField;

public class ToActiveFieldCommandRequest:IRequest<ToActiveFieldCommandResponse>
{
    public string? Id { get; set; }
}