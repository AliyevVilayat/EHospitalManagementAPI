using EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.DeleteReceptionist;

public class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommandRequest, DeleteReceptionistCommandResponse>
{
    private readonly IReceptionistService _receptionistService;

    public DeleteReceptionistCommandHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }
    public async Task<DeleteReceptionistCommandResponse> Handle(DeleteReceptionistCommandRequest request, CancellationToken cancellationToken)
    {
        await _receptionistService.DeleteReceptionistAsync(request.IdStr);
        DeleteReceptionistCommandResponse response = new() { Message = "Receptionist successfully deleted" };
        return response;
    }
}
