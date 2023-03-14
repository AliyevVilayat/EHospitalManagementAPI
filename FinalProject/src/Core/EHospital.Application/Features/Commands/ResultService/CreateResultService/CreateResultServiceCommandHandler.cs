using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.CreateResultService;

public class CreateResultServiceCommandHandler : IRequestHandler<CreateResultServiceCommandRequest, CreateResultServiceCommandResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public CreateResultServiceCommandHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<CreateResultServiceCommandResponse> Handle(CreateResultServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _resultServiceService.CreateResultServiceAsync(request.ResultServicePostDTO);
        CreateResultServiceCommandResponse response = new() { Message = "ResultService successfully created" };
        return response;
    }
}
