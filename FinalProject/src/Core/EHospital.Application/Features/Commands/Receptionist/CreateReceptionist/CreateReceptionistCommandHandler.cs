using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;

public class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommandRequest, CreateReceptionistCommandResponse>
{
    private readonly IReceptionistService _receptionistService;

    public CreateReceptionistCommandHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }

    public async Task<CreateReceptionistCommandResponse> Handle(CreateReceptionistCommandRequest request, CancellationToken cancellationToken)
    {
        await _receptionistService.CreateReceptionistAsync(request.ReceptionistPostDTO);
        CreateReceptionistCommandResponse response = new() { Message = "Receptionist successfully created" };
        return response;
    }
}
