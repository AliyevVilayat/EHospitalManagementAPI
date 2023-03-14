using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Field.UpdateField;

public class UpdateFieldCommandRequest:IRequest<UpdateFieldCommandResponse>
{
    public FieldPutDTO FieldPutDTO { get; set; }
}
