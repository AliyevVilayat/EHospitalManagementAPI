using EHospital.Application.Features.Commands.Insurance.CreateInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Field.CreateField;

public class CreateFieldCommandHandler : IRequestHandler<CreateFieldCommandRequest, CreateFieldCommandResponse>
{
    private readonly IFieldService _fieldService;

    public CreateFieldCommandHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }

    public async Task<CreateFieldCommandResponse> Handle(CreateFieldCommandRequest request, CancellationToken cancellationToken)
    {
        await _fieldService.CreateFieldAsync(request.FieldPostDTO);
        CreateFieldCommandResponse response = new() { Message = "Field successfully created" };
        return response;
    }
}
