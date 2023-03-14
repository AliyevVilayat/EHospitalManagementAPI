using EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.UpdateReceptionist;

public class UpdateReceptionistCommandHandler : IRequestHandler<UpdateReceptionistCommandRequest, UpdateReceptionistCommandResponse>
{
    private readonly IReceptionistService _receptionistService;

    public UpdateReceptionistCommandHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }

    public async Task<UpdateReceptionistCommandResponse> Handle(UpdateReceptionistCommandRequest request, CancellationToken cancellationToken)
    {
        await _receptionistService.UpdateReceptionistAsync(request.ReceptionistPutDTO);
        UpdateReceptionistCommandResponse response = new() { Message = "Receptionist successfully updated" };
        return response;
    }
}
