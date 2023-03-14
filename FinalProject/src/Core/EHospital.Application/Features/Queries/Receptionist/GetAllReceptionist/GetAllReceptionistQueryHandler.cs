using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;

public class GetAllReceptionistQueryHandler : IRequestHandler<GetAllReceptionistQueryRequest, GetAllReceptionistQueryResponse>
{
    private readonly IReceptionistService _receptionistService;

    public GetAllReceptionistQueryHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }

    public async Task<GetAllReceptionistQueryResponse> Handle(GetAllReceptionistQueryRequest request, CancellationToken cancellationToken)
    {
        List<ReceptionistGetDTO> receptionistGetDTOs = await _receptionistService.GetAllReceptionistsAsync();
        GetAllReceptionistQueryResponse response = new() { ReceptionistGetDTOs = receptionistGetDTOs, ReceptionistsCount = receptionistGetDTOs.Count };
        return response;
    }
}
