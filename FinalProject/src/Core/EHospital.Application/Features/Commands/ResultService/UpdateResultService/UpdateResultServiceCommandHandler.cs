using EHospital.Application.Features.Commands.ResultService.DeleteResultService;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.UpdateResultService;

public class UpdateResultServiceCommandHandler : IRequestHandler<UpdateResultServiceCommandRequest, UpdateResultServiceCommandResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public UpdateResultServiceCommandHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<UpdateResultServiceCommandResponse> Handle(UpdateResultServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _resultServiceService.UpdateResultServiceAsync(request.ResultServicePutDTO);
        UpdateResultServiceCommandResponse response = new() { Message = "ResultService successfully updated" };
        return response;
    }
}
