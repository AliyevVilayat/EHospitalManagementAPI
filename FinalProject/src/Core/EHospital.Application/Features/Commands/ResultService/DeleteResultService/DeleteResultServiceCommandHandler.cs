using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.ResultService.DeleteResultService;

public class DeleteResultServiceCommandHandler : IRequestHandler<DeleteResultServiceCommandRequest, DeleteResultServiceCommandResponse>
{
    private readonly IResultServiceService _resultServiceService;

    public DeleteResultServiceCommandHandler(IResultServiceService resultServiceService)
    {
        _resultServiceService = resultServiceService;
    }
    public async Task<DeleteResultServiceCommandResponse> Handle(DeleteResultServiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _resultServiceService.DeleteResultServiceAsync(request.IdStr);
        DeleteResultServiceCommandResponse response = new() { Message = "ResultService successfully deleted" };
        return response;
    }
}
