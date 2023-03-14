using MediatR;

namespace EHospital.Application.Features.Commands.Field.DeleteField;

public class DeleteFieldCommandRequest:IRequest<DeleteFieldCommandResponse>
{
    public string? Id { get; set; }
}
