using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Field.CreateField;

public class CreateFieldCommandRequest:IRequest<CreateFieldCommandResponse>
{
    public FieldPostDTO FieldPostDTO { get; set; }
}
