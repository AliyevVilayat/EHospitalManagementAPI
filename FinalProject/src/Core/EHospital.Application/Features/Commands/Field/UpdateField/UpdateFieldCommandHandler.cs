using EHospital.Application.Features.Commands.Insurance.UpdateInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Field.UpdateField;

public class UpdateFieldCommandHandler : IRequestHandler<UpdateFieldCommandRequest, UpdateFieldCommandResponse>
{
    private readonly IFieldService _fieldService;

    public UpdateFieldCommandHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }
    public async Task<UpdateFieldCommandResponse> Handle(UpdateFieldCommandRequest request, CancellationToken cancellationToken)
    {
        await _fieldService.UpdateFieldAsync(request.FieldPutDTO);
        UpdateFieldCommandResponse response = new() { Message = "Field successfully updated" };
        return response;
    }
}
