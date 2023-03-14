using EHospital.Application.Features.Commands.Field.UpdateField;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Field.DeleteField;

public class DeleteFieldCommandHandler : IRequestHandler<DeleteFieldCommandRequest, DeleteFieldCommandResponse>
{
    private readonly IFieldService _fieldService;

    public DeleteFieldCommandHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }
    public async Task<DeleteFieldCommandResponse> Handle(DeleteFieldCommandRequest request, CancellationToken cancellationToken)
    {
        await _fieldService.DeleteFieldAsync(request.Id);
        DeleteFieldCommandResponse response = new() { Message = "Field successfully deleted" };
        return response;
    }
}
